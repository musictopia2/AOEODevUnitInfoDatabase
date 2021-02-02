using CommonBasicStandardLibraries.CollectionClasses;
using FirstDataModelLibrary;
using ll = CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.FileFunctions.FileLocator;
using aa = DataLocationLibrary.FileHelperClass;
using CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.BasicExtensions;
using CommonBasicStandardLibraries.BasicDataSettingsAndProcesses;
using System.Threading.Tasks;
using ff = CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.JsonSerializers.FileHelpers;
namespace CaptureFirstData
{
    class Program
    {
        static async Task Main()
        {
            aa.Setup();

            //await CreateUpgradeModelData();
            await CreateDatabaseModelData();

        }

        static async Task CreateDatabaseModelData()
        {
            string originalName = ll.GetLocation(aa.OriginalExcelDatabase);
            CustomBasicList<FullDatabaseModel> list = await originalName.LoadTextListAsync<FullDatabaseModel>(Constants.vbTab);
            string newName = ll.GetLocation(aa.FirstParsedExcelDatabase);
            await ff.SaveObjectAsync(newName, list);
        }

        static async Task CreateUpgradeModelData()
        {
            string originalName = ll.GetLocation(aa.OriginalExcelUpgrades);
            CustomBasicList<UpgradeModel> list = await originalName.LoadTextListAsync<UpgradeModel>(Constants.vbTab);
            string newName = ll.GetLocation(aa.FirstParsedExcelUpgrades);
            await ff.SaveObjectAsync(newName, list);
            //string text = await ff.AllTextAsync(originalName);
            //CustomBasicList<string> firsts = text.Split(Constants.vbCrLf).ToCustomBasicList();

            //foreach (var item in firsts)
            //{
            //    CustomBasicList<string> nexts = item.Split(Constants.vbTab).ToCustomBasicList();
            //    System.Console.WriteLine(nexts.Count);
            //}

            

        }


    }
}
