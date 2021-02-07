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
    public class TechService : ITechService
    {
        private CustomBasicList<TechnologyModel> _allTechs = new CustomBasicList<TechnologyModel>();
        private readonly string _fileName = "PhaseUpgrade5.json";
        private readonly Assembly _a;
        public TechService()
        {
            _a = Assembly.GetAssembly(GetType());
        }
        private async Task GetAllTechsAsync()
        {
            if (_allTechs.Count > 0)
            {
                return; //because we already have now.
            }
            string text = await _a.ResourcesAllTextFromFileAsync(_fileName);
            _allTechs = await js.DeserializeObjectAsync<CustomBasicList<TechnologyModel>>(text);
            _allTechs = _allTechs.OrderBy(xxx => xxx.Name).ToCustomBasicList(); //this will sort.  i think its best to let this one sort.
        }
        public async Task<CustomBasicList<TechnologyModel>> GetAllAttackTechsAsync()
        {
            await GetAllTechsAsync();
            return _allTechs.Where(xxx => xxx.Attack).ToCustomBasicList();
        }
        public async Task<CustomBasicList<TechnologyModel>> GetAllDefenseTechsAsync()
        {
            await GetAllTechsAsync();
            return _allTechs.Where(xxx => xxx.Defense).ToCustomBasicList();
        }
    }
}