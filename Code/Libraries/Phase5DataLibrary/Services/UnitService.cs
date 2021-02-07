using CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.BasicExtensions;
using CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.FileFunctions;
using CommonBasicStandardLibraries.CollectionClasses;
using Phase5DataLibrary.Models;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using js = CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.JsonSerializers.NewtonJsonStrings;
namespace Phase5DataLibrary.Services
{
    public class UnitService : IUnitService
    {
        CustomBasicList<UnitModel> _allUnits = new CustomBasicList<UnitModel>();
        private readonly string _fileName = "Phase4.json";
        private readonly Assembly _a;
        public UnitService()
        {
            _a = Assembly.GetAssembly(GetType());
        }
        private async Task GetAllUnitsAsync()
        {
            if (_allUnits.Count > 0)
                return; //because we already have now.
            string text = await _a.ResourcesAllTextFromFileAsync(_fileName);
            _allUnits = await js.DeserializeObjectAsync<CustomBasicList<UnitModel>>(text);
            _allUnits = _allUnits.OrderBy(xxx => xxx.UnitName).ToCustomBasicList(); //this will sort.  i think its best to let this one sort.
        }
        public async Task<CustomBasicList<UnitModel>> GetAllAttackUnitsAsync()
        {
            await GetAllUnitsAsync();
            CustomBasicList<UnitModel> output = _allUnits.Where(xxx => xxx.IsAttacker).ToCustomBasicList();
            return output;
        }
        public async Task<CustomBasicList<UnitModel>> GetAllDefenseUnitsAsync()
        {
            await GetAllUnitsAsync();
            return _allUnits.ToCustomBasicList(); //i think this one should be all units after all.
        }
        public async Task<CustomBasicList<string>> GetAttackUnitsAsync()
        {
            await GetAllUnitsAsync();
            CustomBasicList<string> output = _allUnits.Where(xxx => xxx.IsAttacker).GroupBy(xxx => xxx.UnitName).Select(xxx => xxx.Key).ToCustomBasicList(); //i think.
            return output;
        }
        public async Task<CustomBasicList<UnitModel>> GetAttackUnitsAsync(string unitRequested)
        {
            await GetAllUnitsAsync();
            CustomBasicList<UnitModel> output = _allUnits.Where(xxx => xxx.UnitName == unitRequested && xxx.IsAttacker).ToCustomBasicList();
            return output;
        }
        public async Task<CustomBasicList<string>> GetDefenseUnitsAsync()
        {
            await GetAllUnitsAsync();
            CustomBasicList<string> output = _allUnits.GroupBy(xxx => xxx.UnitName).Select(xxx => xxx.Key).ToCustomBasicList();
            return output;
        }
        public async Task<CustomBasicList<UnitModel>> GetDefenseUnitsAsync(string unitRequested)
        {
            await GetAllUnitsAsync();
            CustomBasicList<UnitModel> output = _allUnits.Where(xxx => xxx.UnitName == unitRequested).ToCustomBasicList();
            return output;
        }
    }
}