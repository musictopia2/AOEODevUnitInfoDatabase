using CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.BasicExtensions;
using CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.FileFunctions;
using CommonBasicStandardLibraries.CollectionClasses;
using CommonBasicStandardLibraries.Exceptions;
using Phase1DataLibrary.Models;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using js = CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.JsonSerializers.NewtonJsonStrings;
namespace Phase1DataLibrary.Services
{
    public class UnitService : IUnitService
    {
        CustomBasicList<AttackUnitModel> _units = new CustomBasicList<AttackUnitModel>();
        private readonly string _fileName = "Phase1.json";
        private readonly Assembly _a;
        public UnitService()
        {
            _a = Assembly.GetAssembly(GetType());
        }
        public async Task<CustomBasicList<AttackUnitModel>> GetAllUnitsAsync() //if the report wants to sort, easy enough to do obviously.
        {
            string text = await _a.ResourcesAllTextFromFileAsync(_fileName);
            CustomBasicList<AttackUnitModel> output = await js.DeserializeObjectAsync<CustomBasicList<AttackUnitModel>>(text);
            return output;
        }
        public async Task<CustomBasicList<string>> GetUnitsAsync()
        {
            if (_units.Count == 0)
            {
                _units = await GetAllUnitsAsync();
            }
            if (_units.Count == 0)
            {
                throw new BasicBlankException("There are no units.  Rethink");
            }
            CustomBasicList<string> output = _units.GroupBy(xxx => xxx.UnitName).Select(xxx => xxx.Key).OrderBy(xxx => xxx).ToCustomBasicList();
            return output;
        }
        public Task<CustomBasicList<AttackUnitModel>> GetUnitsAsync(string unitRequested)
        {
            CustomBasicList<AttackUnitModel> output = _units.Where(xxx => xxx.UnitName == unitRequested).ToCustomBasicList();
            return Task.FromResult(output); //this one is not async.  but there could be an api call that is async.
        }
    }
}