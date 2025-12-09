
using System;
using System.IO;
using System.Data;
using System.Text;
using System.Globalization;
using System.Collections.Generic;
using SyncroSim.Core;

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
                throw new TransformerCanceledException("An output library path must be specified before running the Export transformer.");
            }

            string exportLibraryFilePath = Convert.ToString(exportLibraryPathTable.Rows[0]["Path"], CultureInfo.InvariantCulture);

            if (File.Exists(exportLibraryFilePath))
            {
                throw new TransformerCanceledException("The specified output library already exists. Please choose a different file name.");
            }

            this.CreateLibraryFromStrata(exportLibraryFilePath);
        }

        private void CreateLibraryFromStrata(string targetFileName)
        {
            File.Copy(this.Library.Connection.ConnectionString, targetFileName);

            string KeepStratumIdString = CreateKeepStratumIdString();
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

        private string CreateKeepStratumIdString()
        {
            DataSheet exportStrataDataSheet = this.Scenario.GetDataSheet("landfirevegmodels_ExportStrata");
            StringBuilder sb = new StringBuilder();

            foreach (DataRow dr in exportStrataDataSheet.GetData().Rows)
            {
                sb.AppendFormat(CultureInfo.InvariantCulture, "{0},", Convert.ToInt32(dr["StratumID"]));
            }

            if (sb.Length == 0)
            {
                throw new TransformerCanceledException("At least one stratum needs to be selected for export.");
            }

            return sb.ToString().TrimEnd(',');
        }
    }
}
