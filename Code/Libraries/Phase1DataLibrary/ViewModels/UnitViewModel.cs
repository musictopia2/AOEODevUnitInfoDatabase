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

        private CustomBasicList<string> _upgrades = new CustomBasicList<string>();

        public UnitViewModel(IUnitService service)
        {
            _service = service;
            _upgrades = new CustomBasicList<string>()
            {
                "Base",
                "Champion"
            };
            //TechList = new CustomBasicList<string>()
            //{
            //    "Base",
            //    "Champion"
            //};
        }
        public string CivilizationRequested { get; set; } = "";
        public string UnitRequested { get; set; } = "";
        public CustomBasicList<string> Civilizations { get; private set; } = new CustomBasicList<string>();
        public CustomBasicList<string> UnitStringList { get; private set; } = new CustomBasicList<string>();
        public CustomBasicList<AttackUnitModel> UnitAttackList { get; private set; } = new CustomBasicList<AttackUnitModel>();
        public string BaseString { get; set; } = "";
        public CustomBasicList<string> UpgradeList { get; private set; } = new CustomBasicList<string>();
        private CustomBasicList<AttackUnitModel> _fullAttackList = new CustomBasicList<AttackUnitModel>();
        public async Task ChoseUnitAsync()
        {
            if (string.IsNullOrWhiteSpace(UnitRequested))
            {
                throw new BasicBlankException("Should not be allowd to get unit information because no unit was chosen");
            }
            _fullAttackList = await _service.GetUnitsAsync(UnitRequested);
            UnitAttackList = _fullAttackList.ToCustomBasicList();
            Civilizations = UnitAttackList.GroupBy(xxx => xxx.Civilization).Select(xxx => xxx.Key).OrderBy(xxx => xxx).ToCustomBasicList();
            if (UnitAttackList.Any(xxx => xxx.Champion))
            {
                UpgradeList = _upgrades.ToCustomBasicList();
            }
            else
            {
                UpgradeList = new CustomBasicList<string>(); //because no need to select if no choices.
            }
            if (Civilizations.Count == 1)
            {
                Civilizations = new CustomBasicList<string>(); //seems silly to choose civilzation if there is only one civilization.
            }
        }
        public void Clear()
        {
            CivilizationRequested = "";
            UnitAttackList.Clear();
            _fullAttackList.Clear();
            Civilizations.Clear();
            UnitRequested = "";
            BaseString = "";
            UpgradeList.Clear();
        }
        public void FilterCivilization()
        {
            UnitAttackList = _fullAttackList.Where(xxx => xxx.Civilization == CivilizationRequested).ToCustomBasicList();
        }
        public async Task InitAsync()
        {
            UnitStringList = await _service.GetUnitsAsync();
        }
        public void FilterBaseChampion()
        {
            if (BaseString == "")
            {
                throw new BasicBlankException("No need to filter base because not even entered");
            }
            if (CivilizationRequested != "")
            {
                FilterCivilization(); //just in case.
                if (BaseString == "Champion")
                {
                    UnitAttackList.RemoveAllAndObtain(xxx => xxx.Champion == false);
                    return; 
                }
                if (BaseString == "Base")
                {
                    UnitAttackList.RemoveAllAndObtain(xxx => xxx.Champion); //should already do the filters
                    return;
                }
            }
            if (BaseString == "Champion")
            {
                UnitAttackList = _fullAttackList.Where(xxx => xxx.Champion).ToCustomBasicList();
                return;
            }
            if (BaseString == "Base")
            {
                UnitAttackList = _fullAttackList.Where(xxx => xxx.Champion == false).ToCustomBasicList();
                return;
            }
            throw new BasicBlankException($"Only Base And Chamption Are Supported, Not {BaseString}");
        }
    }
}