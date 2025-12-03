using SyncroSim.Core;

namespace LandFireVegModels
{
    internal class Updates : DotNetUpdateProvider
    {
        [UpdateAttribute(2.0, "This update serves as a new base schema version for landfirevegmodels in SyncroSim 3")]
        public static void Update_2_000(DataStore store)
        {
            // Fix typo (three 'c' in succession) in primary key column
            RenameColumn(store, "landfirevegmodels_SuccessionClassDescription", "SucccessionClassDescriptionID", "SuccessionClassDescriptionId");
        }
    }
}
