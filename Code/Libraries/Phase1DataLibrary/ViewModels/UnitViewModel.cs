using CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.BasicExtensions;
using CommonBasicStandardLibraries.CollectionClasses;
using CommonBasicStandardLibraries.Exceptions;
using Phase1DataLibrary.Models;
using Phase1DataLibrary.Services;
using System.Linq;
using System.Threading.Tasks;
namespace Phase1DataLibrary.ViewModels
{
    public class UnitViewModel : IUnitViewModel
    {
        private readonly IUnitService _service;
        public UnitViewModel(IUnitService service)
        {
            _service = service;
        }
        public string CivilizationRequested { get; set; } = "";
        public string UnitRequested { get; set; } = "";
        public CustomBasicList<string> Civilizations { get; private set; }
        public CustomBasicList<string> UnitStringList { get; private set; }
        public CustomBasicList<AttackUnitModel> UnitAttackList { get; private set; }
        private CustomBasicList<AttackUnitModel> _fullAttackList = new CustomBasicList<AttackUnitModel>();
        public async Task ChoseUnitAsync()
        {
            if (string.IsNullOrWhiteSpace(UnitRequested))
            {
                throw new BasicBlankException("Should not be allowd to get unit information because no unit was chosen");
            }
            _fullAttackList = await _service.GetUnitsAsync(UnitRequested);
            UnitAttackList = _fullAttackList.ToCustomBasicList();
        }
        public void Clear()
        {
            CivilizationRequested = "";
            UnitAttackList.Clear();
            _fullAttackList.Clear();
            Civilizations.Clear();
            UnitRequested = "";
        }
        public void FilterCivilization()
        {
            UnitAttackList = _fullAttackList.Where(xxx => xxx.Civilization == CivilizationRequested).ToCustomBasicList();
        }
        public async Task InitAsync()
        {
            UnitStringList = await _service.GetUnitsAsync();
        }
    }
}