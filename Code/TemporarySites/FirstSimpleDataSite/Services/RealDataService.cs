using CommonBasicStandardLibraries.CollectionClasses;
using FirstDataModelLibrary;
using System.Threading.Tasks;
using aa = DataLocationLibrary.FileHelperClass;
using ff = CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.JsonSerializers.FileHelpers;
using ll = CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.FileFunctions.FileLocator;
namespace FirstSimpleDataSite.Services
{
    public class RealDataService : IDataService
    {

        public RealDataService()
        {
            aa.Setup();
        }
        public async Task<CustomBasicList<FullDatabaseModel>> GetEntireDatabaseAsync()
        {
            string fileName = ll.GetLocation(aa.FirstParsedExcelDatabase);
            CustomBasicList<FullDatabaseModel> output = await ff.RetrieveSavedObjectAsync<CustomBasicList<FullDatabaseModel>>(fileName);
            return output;
        }

        public async Task<CustomBasicList<UpgradeModel>> GetUpgradesAsync()
        {
            string fileName = ll.GetLocation(aa.FirstParsedExcelUpgrades);
            CustomBasicList<UpgradeModel> output = await ff.RetrieveSavedObjectAsync<CustomBasicList<UpgradeModel>>(fileName);
            return output;
        }
    }
}
