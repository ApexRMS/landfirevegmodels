using System;
using System.Data;
using System.Globalization;
using SyncroSim.Core;

namespace LandFireVegModels
{
    internal class Updates : DotNetUpdateProvider
    {
        [UpdateAttribute(2.0, "This update adjust tables so landfirevegmodels works with SyncroSim V3 and stsim 4.5.3")]
        public static void Update_2_000(DataStore store)
        {
            store.ExecuteNonQuery("ALTER TABLE stsim_Terminology ADD COLUMN StockUnits TEXT");
            store.ExecuteNonQuery("UPDATE stsim_Terminology SET StockUnits='Tons'");

            RenameColumn(store, "stsim_OutputFilterStateAttributes", "OutputFilterStateAttributeID", "OutputFilterStateAttributesID");
            RenameColumn(store, "stsim_OutputFilterTransitionAttributes", "OutputFilterTransitionAttributeID", "OutputFilterTransitionAttributesID");
            RenameColumn(store, "stsim_Multiprocessing", "ProcessingID", "MultiprocessingID");

            store.ExecuteNonQuery("UPDATE core_Transformer SET Name='stsim_Main' WHERE Name='stsim_Primary'");

            if (!store.TableExists("stsim_Resolution"))
            {
                store.ExecuteNonQuery("CREATE TABLE stsim_Resolution(ResolutionId INTEGER PRIMARY KEY, ProjectId INTEGER, Id INTEGER, Name TEXT)");

                DataTable projectDt = store.CreateDataTable("core_Project");

                foreach (DataRow dr in projectDt.Rows)
                {
                    int pid = Convert.ToInt32(dr["ProjectID"], CultureInfo.InvariantCulture);

                    store.ExecuteNonQuery(string.Format(CultureInfo.InvariantCulture,
                        "INSERT INTO stsim_Resolution(ResolutionId, ProjectId, Id, Name) VALUES({0}, {1}, {2}, 'Base')",
                        Library.GetNextSequenceId(store), pid, 0));
                    store.ExecuteNonQuery(string.Format(CultureInfo.InvariantCulture,
                        "INSERT INTO stsim_Resolution(ResolutionId, ProjectId, Id, Name) VALUES({0}, {1}, {2}, 'Fine')",
                        Library.GetNextSequenceId(store), pid, 1));
                }
            }

            store.ExecuteNonQuery("ALTER TABLE stsim_OutputSpatialState ADD COLUMN ResolutionId INTEGER");
            store.ExecuteNonQuery("UPDATE stsim_OutputSpatialState SET ResolutionId=0");

            store.ExecuteNonQuery("ALTER TABLE stsim_OutputSpatialAge ADD COLUMN ResolutionId INTEGER");
            store.ExecuteNonQuery("UPDATE stsim_OutputSpatialAge SET ResolutionId=0");

            store.ExecuteNonQuery("ALTER TABLE stsim_OutputSpatialStratum ADD COLUMN ResolutionId INTEGER");
            store.ExecuteNonQuery("UPDATE stsim_OutputSpatialStratum SET ResolutionId=0");

            store.ExecuteNonQuery("ALTER TABLE stsim_OutputSpatialTransition ADD COLUMN ResolutionId INTEGER");
            store.ExecuteNonQuery("UPDATE stsim_OutputSpatialTransition SET ResolutionId=0");

            store.ExecuteNonQuery("ALTER TABLE stsim_OutputSpatialTransitionEvent ADD COLUMN ResolutionId INTEGER");
            store.ExecuteNonQuery("UPDATE stsim_OutputSpatialTransitionEvent SET ResolutionId=0");

            store.ExecuteNonQuery("ALTER TABLE stsim_OutputSpatialTST ADD COLUMN ResolutionId INTEGER");
            store.ExecuteNonQuery("UPDATE stsim_OutputSpatialTST SET ResolutionId=0");

            store.ExecuteNonQuery("ALTER TABLE stsim_OutputSpatialStateAttribute ADD COLUMN ResolutionId INTEGER");
            store.ExecuteNonQuery("UPDATE stsim_OutputSpatialStateAttribute SET ResolutionId=0");

            store.ExecuteNonQuery("ALTER TABLE stsim_OutputSpatialTransitionAttribute ADD COLUMN ResolutionId INTEGER");
            store.ExecuteNonQuery("UPDATE stsim_OutputSpatialTransitionAttribute SET ResolutionId=0");

            store.ExecuteNonQuery("ALTER TABLE stsim_OutputSpatialAverageStateClass ADD COLUMN ResolutionId INTEGER");
            store.ExecuteNonQuery("UPDATE stsim_OutputSpatialAverageStateClass SET ResolutionId=0");

            store.ExecuteNonQuery("ALTER TABLE stsim_OutputSpatialAverageAge ADD COLUMN ResolutionId INTEGER");
            store.ExecuteNonQuery("UPDATE stsim_OutputSpatialAverageAge SET ResolutionId=0");

            store.ExecuteNonQuery("ALTER TABLE stsim_OutputSpatialAverageStratum ADD COLUMN ResolutionId INTEGER");
            store.ExecuteNonQuery("UPDATE stsim_OutputSpatialAverageStratum SET ResolutionId=0");

            store.ExecuteNonQuery("ALTER TABLE stsim_OutputSpatialAverageTransitionProbability ADD COLUMN ResolutionId INTEGER");
            store.ExecuteNonQuery("UPDATE stsim_OutputSpatialAverageTransitionProbability SET ResolutionId=0");

            store.ExecuteNonQuery("ALTER TABLE stsim_OutputSpatialAverageTST ADD COLUMN ResolutionId INTEGER");
            store.ExecuteNonQuery("UPDATE stsim_OutputSpatialAverageTST SET ResolutionId=0");

            store.ExecuteNonQuery("ALTER TABLE stsim_OutputSpatialAverageStateAttribute ADD COLUMN ResolutionId INTEGER");
            store.ExecuteNonQuery("UPDATE stsim_OutputSpatialAverageStateAttribute SET ResolutionId=0");

            store.ExecuteNonQuery("ALTER TABLE stsim_OutputSpatialAverageTransitionAttribute ADD COLUMN ResolutionId INTEGER");
            store.ExecuteNonQuery("UPDATE stsim_OutputSpatialAverageTransitionAttribute SET ResolutionId=0");

            if (store.TableExists("stsim_OutputSpatialStockGroup"))
            {
                store.ExecuteNonQuery("ALTER TABLE stsim_OutputSpatialStockGroup ADD COLUMN ResolutionId INTEGER");
                store.ExecuteNonQuery("UPDATE stsim_OutputSpatialStockGroup SET ResolutionId=0");
            }

            if (store.TableExists("stsim_OutputSpatialFlowGroup"))
            {
                store.ExecuteNonQuery("ALTER TABLE stsim_OutputSpatialFlowGroup ADD COLUMN ResolutionId INTEGER");
                store.ExecuteNonQuery("UPDATE stsim_OutputSpatialFlowGroup SET ResolutionId=0");
            }

            if (store.TableExists("stsim_OutputLateralFlowGroup"))
            {
                store.ExecuteNonQuery("ALTER TABLE stsim_OutputLateralFlowGroup ADD COLUMN ResolutionId INTEGER");
                store.ExecuteNonQuery("UPDATE stsim_OutputLateralFlowGroup SET ResolutionId=0");
            }

            if (store.TableExists("stsim_OutputAverageSpatialStockGroup"))
            {
                store.ExecuteNonQuery("ALTER TABLE stsim_OutputAverageSpatialStockGroup ADD COLUMN ResolutionId INTEGER");
                store.ExecuteNonQuery("UPDATE stsim_OutputAverageSpatialStockGroup SET ResolutionId=0");
            }

            if (store.TableExists("stsim_OutputAverageSpatialFlowGroup"))
            {
                store.ExecuteNonQuery("ALTER TABLE stsim_OutputAverageSpatialFlowGroup ADD COLUMN ResolutionId INTEGER");
                store.ExecuteNonQuery("UPDATE stsim_OutputAverageSpatialFlowGroup SET ResolutionId=0");
            }

            if (store.TableExists("stsim_OutputAverageLateralFlowGroup"))
            {
                store.ExecuteNonQuery("ALTER TABLE stsim_OutputAverageLateralFlowGroup ADD COLUMN ResolutionId INTEGER");
                store.ExecuteNonQuery("UPDATE stsim_OutputAverageLateralFlowGroup SET ResolutionId=0");
            }

            store.ExecuteNonQuery("ALTER TABLE stsim_OutputStratum ADD COLUMN ResolutionId INTEGER");
            store.ExecuteNonQuery("UPDATE stsim_OutputStratum SET ResolutionId=0");

            store.ExecuteNonQuery("ALTER TABLE stsim_OutputStratumState ADD COLUMN ResolutionId INTEGER");
            store.ExecuteNonQuery("UPDATE stsim_OutputStratumState SET ResolutionId=0");

            store.ExecuteNonQuery("ALTER TABLE stsim_OutputStratumTransition ADD COLUMN ResolutionId INTEGER");
            store.ExecuteNonQuery("UPDATE stsim_OutputStratumTransition SET ResolutionId=0");

            store.ExecuteNonQuery("ALTER TABLE stsim_OutputStratumTransitionState ADD COLUMN ResolutionId INTEGER");
            store.ExecuteNonQuery("UPDATE stsim_OutputStratumTransitionState SET ResolutionId=0");

            store.ExecuteNonQuery("ALTER TABLE stsim_OutputTST ADD COLUMN ResolutionId INTEGER");
            store.ExecuteNonQuery("UPDATE stsim_OutputTST SET ResolutionId=0");

            store.ExecuteNonQuery("ALTER TABLE stsim_OutputStateAttribute ADD COLUMN ResolutionId INTEGER");
            store.ExecuteNonQuery("UPDATE stsim_OutputStateAttribute SET ResolutionId=0");

            store.ExecuteNonQuery("ALTER TABLE stsim_OutputTransitionAttribute ADD COLUMN ResolutionId INTEGER");
            store.ExecuteNonQuery("UPDATE stsim_OutputTransitionAttribute SET ResolutionId=0");

            DataTable dt = store.CreateDataTable("stsim_OutputExternalVariableValue");

            if (!dt.Columns.Contains("ExternalVariableTypeId"))
            {
                store.ExecuteNonQuery("ALTER TABLE stsim_OutputExternalVariableValue ADD COLUMN ExternalVariableTypeId INTEGER");
            }

            store.ExecuteNonQuery("ALTER TABLE stsim_OutputExternalVariableValue ADD COLUMN ResolutionId INTEGER");
            store.ExecuteNonQuery("UPDATE stsim_OutputExternalVariableValue SET ResolutionId=0");

            // Not sure if these conditionals are needed, but they were used in Update_4_100 for stocks and flows, so assuming they are also needed here
            if (store.TableExists("stsim_OutputStock"))
            {
                store.ExecuteNonQuery("ALTER TABLE stsim_OutputStock ADD COLUMN ResolutionId INTEGER");
                store.ExecuteNonQuery("UPDATE stsim_OutputStock SET ResolutionId=0");
            }

            if (store.TableExists("stsim_OutputFlow"))
            {
                store.ExecuteNonQuery("ALTER TABLE stsim_OutputFlow ADD COLUMN ResolutionId INTEGER");
                store.ExecuteNonQuery("UPDATE stsim_OutputFlow SET ResolutionId=0");
            }

            if (store.TableExists("stsim_OutputOptionsStockFlow"))
            {
                store.ExecuteNonQuery("ALTER TABLE stsim_OutputOptionsStockFlow ADD COLUMN SummaryOutputSTOmitSS INTEGER");
                store.ExecuteNonQuery("ALTER TABLE stsim_OutputOptionsStockFlow ADD COLUMN SummaryOutputSTOmitTS INTEGER");
                store.ExecuteNonQuery("ALTER TABLE stsim_OutputOptionsStockFlow ADD COLUMN SummaryOutputSTOmitSC INTEGER");

                store.ExecuteNonQuery("ALTER TABLE stsim_OutputOptionsStockFlow ADD COLUMN SummaryOutputFLOmitSS INTEGER");
                store.ExecuteNonQuery("ALTER TABLE stsim_OutputOptionsStockFlow ADD COLUMN SummaryOutputFLOmitTS INTEGER");
                store.ExecuteNonQuery("ALTER TABLE stsim_OutputOptionsStockFlow ADD COLUMN SummaryOutputFLOmitFromSC INTEGER");
                store.ExecuteNonQuery("ALTER TABLE stsim_OutputOptionsStockFlow ADD COLUMN SummaryOutputFLOmitFromST INTEGER");
                store.ExecuteNonQuery("ALTER TABLE stsim_OutputOptionsStockFlow ADD COLUMN SummaryOutputFLOmitTT INTEGER");
                store.ExecuteNonQuery("ALTER TABLE stsim_OutputOptionsStockFlow ADD COLUMN SummaryOutputFLOmitToSC INTEGER");
                store.ExecuteNonQuery("ALTER TABLE stsim_OutputOptionsStockFlow ADD COLUMN SummaryOutputFLOmitToST INTEGER");
            }

            if (store.TableExists("stsim_OutputStratumState"))
            {
                store.ExecuteNonQuery("UPDATE stsim_OutputStratumState SET SecondaryStratumId = NULL WHERE SecondaryStratumId = 0");
                store.ExecuteNonQuery("UPDATE stsim_OutputStratumState SET TertiaryStratumId = NULL WHERE TertiaryStratumId = 0");
            }

            // Fix typo (three 'c' in succession) in primary key column
            RenameColumn(store, "landfirevegmodels_SuccessionClassDescription", "SucccessionClassDescriptionID", "SuccessionClassDescriptionId");
        }
    }
}
