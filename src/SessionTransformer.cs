
using System;
using System.IO;
using System.Data;
using System.Text;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using System.Collections.Generic;
using SyncroSim.Core;
using SyncroSim.Core.Forms;

namespace LandFireVegModels
{
    class SessionTransformer : Transformer
    {
        public override void Configure()
        {
            base.Configure();

            WinFormSession wfs = (WinFormSession)this.Session;
            wfs.MainMenuLoaded += this.OnMainMenuLoaded;
        }

        private void OnMainMenuLoaded(object sender, EventArgs e)
        {
            WinFormSession wfs = (WinFormSession)this.Session;
            CommandCollection cmds = wfs.Application.GetMenuCommands();
            Command EditCommand = Command.FindCommand("ssim_edit_menu", cmds);
            Debug.Assert(EditCommand != null);

            if (EditCommand != null)
            {
                EditCommand.Commands.Add(Command.CreateSeparatorCommand());

                Command LFVMExportStrataCmd = new Command(
                    "export-lfvm-strata", 
                    "Export LFVM Strata", 
                    OnExecuteExportStrata, 
                    OnUpdateExportStrata);

                EditCommand.Commands.Add(LFVMExportStrataCmd);
            }
        }

        private void OnUpdateExportStrata(Command cmd)
        {
            cmd.IsEnabled = false;
            WinFormSession wfs = (WinFormSession)this.Session;
            Library lib = wfs.Application.GetSelectedLibrary();

            if (lib != null)
            {
                string ptn = lib.GetPrimaryTransformerName();
                cmd.IsEnabled = (ptn == "landfirevegmodels_landfirevegmodels");
            }
        }

        private void OnExecuteExportStrata(Command cmd)
        {
            ExportStrataForm f = new ExportStrataForm();
            WinFormSession wfs = (WinFormSession)this.Session;
            Library lib = wfs.Application.GetSelectedLibrary();

            if (lib == null)
            {
                Debug.Assert(false);
                return;
            }

            f.Initialize(lib);

            if (f.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            try
            {
                wfs.Application.BeginHourGlass();

                wfs.Application.SetStatusMessageWithEvents(
                    "Creating Library from selected strata...");

                //Create
                this.CreateLibraryFromStrata(
                    lib,
                    f.FileName,
                    f.GetSelectedStratumIds());

                //Compact
                this.Session.CompactLibrary(f.FileName);

                //Open
                wfs.Application.OpenLibrary(f.FileName);
            }
            catch(Exception ex)
            {
                string msg =
                    "Cannot create a Library.  More information:" +
                    Environment.NewLine +
                    Environment.NewLine +
                    ex.Message;

                Shared.ShowMessageBox(msg, MessageBoxButtons.OK);
            }

            finally
            {
                wfs.Application.SetStatusMessageWithEvents(null);
                wfs.Application.EndHourGlass();
            }
        }

        private void CreateLibraryFromStrata(
            Library sourceLibrary, 
            string targetFileName, 
            List<int> keepStratumIds)
        {
            CreateTargetLibrary(sourceLibrary, targetFileName);

            WinFormSession wfs = (WinFormSession)this.Session;
            string KeepStratumIdString = CreateKeepStratumIdString(keepStratumIds);
            DataStoreConnection conn = new DataStoreConnection("SQLite", targetFileName);

            using (SyncroSimTransactionScope scope = Session.CreateTransactionScope())
            {
                using (DataStore store = Session.CreateDataStore(conn))
                {
                    DataTable AllTables = store.CreateDataTableFromQuery(
                        "SELECT name FROM sqlite_master WHERE type='table'",
                        "AllTables");

                    foreach (DataRow dr in AllTables.Rows)
                    {
                        string TableName = Convert.ToString(dr["name"]);

                        if (!ShouldProcessTable(TableName))
                        {
                            continue;
                        }

                        DataTable TableSchema = GetTableSchema(TableName, store);

                        if (TableSchema.Columns.Contains("StratumID"))
                        {
                            PurgeStratumIds(TableName, "StratumID", KeepStratumIdString, store);
                        }

                        if (TableSchema.Columns.Contains("StratumIDSource"))
                        {
                            PurgeStratumIds(TableName, "StratumIDSource", KeepStratumIdString, store);
                        }

                        if (TableSchema.Columns.Contains("StratumIDDest"))
                        {
                            PurgeStratumIds(TableName, "StratumIDDest", KeepStratumIdString, store);
                        }
                    }
                }

                scope.Complete();
            }
        }

        private static void CreateTargetLibrary(Library sourceLibrary, string targetFileName)
        {
            if (File.Exists(targetFileName))
            {
                File.Delete(targetFileName);
            }

            File.Copy(
                sourceLibrary.Connection.ConnectionString,
                targetFileName);
        }

        private static void PurgeStratumIds(
            string tableName, 
            string columnName, 
            string keepStratumIds, 
            DataStore store)
        {
            string q = string.Format(CultureInfo.InvariantCulture,
                "DELETE FROM {0} WHERE {1}.{2} NOT IN ({3})",
                tableName,
                tableName,
                columnName,
                keepStratumIds);

            store.ExecuteNonQuery(q);
        }

        private static DataTable GetTableSchema(string tableName, DataStore store)
        {
            string q = string.Format(CultureInfo.InvariantCulture,
                "SELECT * FROM {0} LIMIT 0", tableName);

            return store.CreateDataTableFromQuery(q, "Table");
        }

        private static bool ShouldProcessTable(string tableName)
        {
            if (!tableName.StartsWith("stsim_") && 
                !tableName.StartsWith("landfirevegmodels_"))
            {
                return false;
            }

            return true;
        }

        private string CreateKeepStratumIdString(List<int> stratumIds)
        {
            StringBuilder sb = new StringBuilder();

            foreach (int id in stratumIds)
            {
                sb.AppendFormat(CultureInfo.InvariantCulture, "{0},", id);
            }

            return sb.ToString().TrimEnd(',');
        }
    }
}
