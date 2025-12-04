
using System;
using System.IO;
using System.Data;
using System.Text;
using System.Globalization;
using System.Collections.Generic;
using SyncroSim.Core;
using SyncroSim.Core.Forms;

namespace LandFireVegModels
{
    class ExportTransformer : Transformer
    {
        public override void Transform()
        {
            DataSheet exportLibraryPathDataSheet = this.Scenario.GetDataSheet("landfirevegmodels_ExportLibraryPath");
            DataTable exportLibraryPathTable = exportLibraryPathDataSheet.GetData();
            if (exportLibraryPathTable.Rows.Count == 0 ||
                object.ReferenceEquals(exportLibraryPathTable.Rows[0]["Path"], DBNull.Value))
            {
                throw new TransformerCanceledException(
                "An output library path must be specified before running the Export transformer.");
            }

            string exportLibraryFilePath =
            Convert.ToString(exportLibraryPathTable.Rows[0]["Path"], CultureInfo.InvariantCulture);

            this.CreateLibraryFromStrata(
                this.Library,
                exportLibraryFilePath,
                GetSelectedStratumIds());
        }

        private List<int> GetSelectedStratumIds()
        {
            List<int> Ids = new List<int>();

            DataSheet exportStrataDataSheet = this.Scenario.GetDataSheet("landfirevegmodels_ExportStrata");

            foreach (DataRow dr in exportStrataDataSheet.GetData().Rows)
            {
                Ids.Add(Convert.ToInt32(dr["StratumID"]));
            }

            if (Ids.Count == 0)
            {
                throw new TransformerCanceledException("At least one stratum needs to be selected for export.");
            }

            return Ids;
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

                    string Title = Path.GetFileNameWithoutExtension(targetFileName);
                    string EscapedTitle = Title.Replace("'", "''");
                    string q = string.Format(CultureInfo.InvariantCulture, "UPDATE core_Library SET Name='{0}'", EscapedTitle);

                    store.ExecuteNonQuery(q);
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
