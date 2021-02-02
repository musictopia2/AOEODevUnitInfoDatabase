using ll = CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.FileFunctions.FileLocator;
namespace DataLocationLibrary
{
    public static class FileHelperClass
    {
        public const string OriginalExcelDatabase = @"RawData\ExcelDatabase.txt";
        public const string OriginalExcelUpgrades = @"RawData\ExcelUpgrade.txt";
        public const string FirstParsedExcelDatabase = @"ParsedData\ExcelDatabase.json";
        public const string FirstParsedExcelUpgrades = @"ParsedData\ExcelUpgrade.json";

        public const string UpgradeModelLocation = @"ParsedData\DatabaseModel.txt";
        public const string DatabaseModelLocation = @"ParsedData\UpgradeModel.txt";

        public const string DatabaseHeaders = @"RawData\ExcelDatabaseHeaders.txt";
        public const string ExcelUpgradeHeaders = @"RawData\ExcelUpgradeHeaders.txt";

        public static void Setup()
        {
            ll.MainLocation = "AOEODevUnitInfoDatabase";
        }

    }
}