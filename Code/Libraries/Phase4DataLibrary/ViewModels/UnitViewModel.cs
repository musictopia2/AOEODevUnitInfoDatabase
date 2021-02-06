using CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.BasicExtensions;
using CommonBasicStandardLibraries.CollectionClasses;
using CommonBasicStandardLibraries.Exceptions;
using Phase4DataLibrary.Models;
using Phase4DataLibrary.Services;
using System.Linq;
using System.Threading.Tasks;
namespace Phase3DataLibrary.ViewModels
{
    public class UnitViewModel : IUnitViewModel
    {
        private readonly IUnitService _service;
        private readonly CustomBasicList<string> _upgrades = new CustomBasicList<string>();
        private CustomBasicList<UnitModel> _fullAttackList = new CustomBasicList<UnitModel>();
        private CustomBasicList<UnitModel> _fullDefenseList = new CustomBasicList<UnitModel>();
        public UnitViewModel(IUnitService service)
        {
            _service = service;
            _upgrades = new CustomBasicList<string>()
            {
                "Base",
                "Champion"
            };
        }
        public CustomBasicList<string> AttackUnitStringList { get; private set; } = new CustomBasicList<string>();
        public CustomBasicList<string> DefenseUnitStringList { get; private set; } = new();
        public string AttackUnitRequested { get; set; } = "";
        public string DefenseUnitRequested { get; set; } = "";
        public CustomBasicList<string> AttackCivilizations { get; private set; } = new();
        public CustomBasicList<string> DefenseCivilizations { get; private set; } = new();
        public string AttackCivilizationRequested { get; set; } = "";
        public string AttackBaseString { get; set; } = "";
        public string DefenseCivilizationRequested { get; set; } = "";
        public string DefenseBaseString { get; set; } = "";
        public CustomBasicList<UnitModel> UnitAttackList { get; private set; } = new();
        public CustomBasicList<string> AttackUpgradeList { get; private set; } = new();
        public CustomBasicList<UnitModel> UnitDefenseList { get; private set; } = new();
        public CustomBasicList<string> DefenseUpgradeList { get; private set; } = new();

        public async Task ChoseAttackUnitAsync()
        {
            if (string.IsNullOrWhiteSpace(AttackUnitRequested))
            {
                throw new BasicBlankException("Should not be allowd to get unit information because no unit was chosen");
            }
            _fullAttackList = await _service.GetAttackUnitsAsync(AttackUnitRequested);
            UnitAttackList = _fullAttackList.ToCustomBasicList();
            AttackCivilizations = UnitAttackList.GroupBy(xxx => xxx.Civilization).Select(xxx => xxx.Key).OrderBy(xxx => xxx).ToCustomBasicList();
            if (UnitAttackList.Any(xxx => xxx.Champion))
            {
                AttackUpgradeList = _upgrades.ToCustomBasicList();
            }
            else
            {
                AttackUpgradeList = new CustomBasicList<string>(); //because no need to select if no choices.
            }
            if (AttackCivilizations.Count == 1)
            {
                AttackCivilizations = new CustomBasicList<string>(); //seems silly to choose civilzation if there is only one civilization.
            }
        }

        public async Task ChoseDefenseUnitAsync()
        {
            if (string.IsNullOrWhiteSpace(DefenseUnitRequested))
            {
                throw new BasicBlankException("Should not be allowd to get unit information because no unit was chosen");
            }
            _fullDefenseList = await _service.GetDefenseUnitsAsync(DefenseUnitRequested);
            UnitDefenseList = _fullDefenseList.ToCustomBasicList();
            DefenseCivilizations = UnitDefenseList.GroupBy(xxx => xxx.Civilization).Select(xxx => xxx.Key).OrderBy(xxx => xxx).ToCustomBasicList();
            if (UnitDefenseList.Any(xxx => xxx.Champion))
            {
                DefenseUpgradeList = _upgrades.ToCustomBasicList();
            }
            else
            {
                DefenseUpgradeList = new CustomBasicList<string>(); //because no need to select if no choices.
            }
            if (DefenseCivilizations.Count == 1)
            {
                DefenseCivilizations = new CustomBasicList<string>(); //seems silly to choose civilzation if there is only one civilization.
            }
        }

        public void Clear()
        {
            AttackCivilizationRequested = "";
            DefenseCivilizationRequested = "";
            UnitAttackList.Clear();
            UnitDefenseList.Clear();
            _fullAttackList.Clear();
            _fullDefenseList.Clear();
            AttackCivilizations.Clear();
            DefenseCivilizations.Clear();
            AttackUnitRequested = "";
            DefenseUnitRequested = "";
            AttackBaseString = "";
            DefenseBaseString = "";
            AttackUpgradeList.Clear();
            DefenseUpgradeList.Clear();
        }

        public void FilterAttackBaseChampion()
        {
            if (AttackBaseString == "")
            {
                throw new BasicBlankException("No need to filter base because not even entered");
            }
            if (AttackCivilizationRequested != "")
            {
                FilterAttackCivilization(); //just in case.
                if (AttackBaseString == "Champion")
                {
                    UnitAttackList.RemoveAllAndObtain(xxx => xxx.Champion == false);
                    return;
                }
                if (AttackBaseString == "Base")
                {
                    UnitAttackList.RemoveAllAndObtain(xxx => xxx.Champion); //should already do the filters
                    return;
                }
            }
            if (AttackBaseString == "Champion")
            {
                UnitAttackList = _fullAttackList.Where(xxx => xxx.Champion).ToCustomBasicList();
                return;
            }
            if (AttackBaseString == "Base")
            {
                UnitAttackList = _fullAttackList.Where(xxx => xxx.Champion == false).ToCustomBasicList();
                return;
            }
            throw new BasicBlankException($"Only Base And Chamption Are Supported, Not {AttackBaseString}");
        }

        public void FilterAttackCivilization()
        {
            UnitAttackList = _fullAttackList.Where(xxx => xxx.Civilization == AttackCivilizationRequested).ToCustomBasicList();
        }

        public void FilterDefenseBaseChampion()
        {
            if (DefenseBaseString == "")
            {
                throw new BasicBlankException("No need to filter base because not even entered");
            }
            if (DefenseCivilizationRequested != "")
            {
                FilterDefenseCivilization(); //just in case.
                if (DefenseBaseString == "Champion")
                {
                    UnitDefenseList.RemoveAllAndObtain(xxx => xxx.Champion == false);
                    return;
                }
                if (DefenseBaseString == "Base")
                {
                    UnitDefenseList.RemoveAllAndObtain(xxx => xxx.Champion); //should already do the filters
                    return;
                }
            }
            if (DefenseBaseString == "Champion")
            {
                UnitDefenseList = _fullAttackList.Where(xxx => xxx.Champion).ToCustomBasicList();
                return;
            }
            if (DefenseBaseString == "Base")
            {
                UnitDefenseList = _fullAttackList.Where(xxx => xxx.Champion == false).ToCustomBasicList();
                return;
            }
            throw new BasicBlankException($"Only Base And Chamption Are Supported, Not {DefenseBaseString}");
        }

        public void FilterDefenseCivilization()
        {
            UnitDefenseList = _fullDefenseList.Where(xxx => xxx.Civilization == DefenseCivilizationRequested).ToCustomBasicList();
        }

        public async Task InitAsync()
        {
            AttackUnitStringList = await _service.GetAttackUnitsAsync();
            DefenseUnitStringList = await _service.GetDefenseUnitsAsync();
        }
    }
}