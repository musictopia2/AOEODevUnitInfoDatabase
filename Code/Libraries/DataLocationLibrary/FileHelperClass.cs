using ll = CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.FileFunctions.FileLocator;
namespace DataLocationLibrary
{
    public static class FileHelperClass
    {
        public const string OriginalExcelDatabase = @"RawData\ExcelDatabase.txt";
        public const string OriginalExcelUpgrades = @"RawData\ExcelUpgrade.txt";
        public const string FirstParsedExcelDatabase = @"ParsedData\ExcelDatabase.json";
        public const string FirstParsedExcelUpgrades = @"ParsedData\ExcelUpgrade.json";

        public const string UpgradeModelLocation = @"ParsedData\UpgradeModel.txt";
        public const string DatabaseModelLocation = @"ParsedData\DatabaseModel.txt";

        public const string DatabaseHeaders = @"RawData\ExcelDatabaseHeaders.txt";
        public const string ExcelUpgradeHeaders = @"RawData\ExcelUpgradeHeaders.txt";

        public static void Setup()
        {
            ll.MainLocation = "AOEODevUnitInfoDatabase";
            CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.JsonSerializers.JsonSettingsGlobals.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None;
            CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.JsonSerializers.JsonSettingsGlobals.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.None;
            //these 2 was needed to insure that when saving, more flexible when reading the information.
        }

    }
}