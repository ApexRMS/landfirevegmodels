
using System;
using System.IO;
using System.Data;
using System.Text;
using System.Globalization;
using SyncroSim.Core;
using System.Linq;
using System.Collections.Generic;

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
                    store.ExecuteNonQuery(string.Format(CultureInfo.InvariantCulture, "UPDATE core_Library SET Name='{0}'", EscapedTitle));

                    string ResultScenarioIdsToPurge = CreatePurgeResultScenarioIdString(store);
                    if (!string.IsNullOrWhiteSpace(ResultScenarioIdsToPurge))
                    {
                        PurgeResultScenarios(store, ResultScenarioIdsToPurge);
                    }
                }

                scope.Complete();
            }

            //Note: this cannot be done within a transaction, so it has to be a separate step.
            using (DataStore store = Session.CreateDataStore(conn))
            {
                store.Compact();
            }
        }

        private void PurgeResultScenarios(DataStore store, string ResultScenarioIdsToPurge)
        {
            List<string> ScenarioDataSheetNames = this.Scenario.DataFeeds
                .SelectMany(df => df.DataSheets)
                .Where(ds => ds.DataScope == DataScope.Scenario)
                .Select(ds => ds.Name)
                .ToList();

            foreach (string name in ScenarioDataSheetNames)
            {
                store.ExecuteNonQuery(string.Format(CultureInfo.InvariantCulture,
                    "DELETE FROM [{0}] WHERE [{1}].{2} IN ({3})",
                    name,
                    name,
                    "ScenarioId",
                    ResultScenarioIdsToPurge));
            }

            store.ExecuteNonQuery(string.Format(CultureInfo.InvariantCulture,
                "DELETE FROM core_ScenarioResult WHERE ResultId IN ({0})", ResultScenarioIdsToPurge));

            store.ExecuteNonQuery(string.Format(CultureInfo.InvariantCulture,
                "DELETE FROM core_Scenario WHERE ScenarioId IN ({0})", ResultScenarioIdsToPurge));
        }

        private static void PurgeStratumIds(
            string tableName,
            string columnName,
            string keepStratumIds,
            DataStore store)
        {
            store.ExecuteNonQuery(string.Format(CultureInfo.InvariantCulture,
                "DELETE FROM {0} WHERE {1}.{2} NOT IN ({3})",
                tableName,
                tableName,
                columnName,
                keepStratumIds));
        }

        private static DataTable GetTableSchema(string tableName, DataStore store)
        {
            return store.CreateDataTableFromQuery(
                string.Format(CultureInfo.InvariantCulture,
                    "SELECT * FROM {0} LIMIT 0",
                    tableName),
                tableName);
        }

        private static bool ShouldProcessTable(string tableName)
        {
            return tableName.StartsWith("stsim_") || tableName.StartsWith("landfirevegmodels_");
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

        private string CreatePurgeResultScenarioIdString(DataStore store)
        {
            DataTable scenarioResultsTable = store.CreateDataTable("core_ScenarioResult");
            StringBuilder sb = new StringBuilder();

            foreach (DataRow dr in scenarioResultsTable.Rows)
            {
                if (Convert.ToInt32(dr["ScenarioID"]) == this.Scenario.Id)
                {
                    sb.AppendFormat(CultureInfo.InvariantCulture, "{0},", dr["ResultID"]);
                }
            }

            return sb.ToString().TrimEnd(',');
        }
    }
}
