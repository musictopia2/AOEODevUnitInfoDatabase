﻿using CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.BasicExtensions;
using CommonBasicStandardLibraries.CollectionClasses;
using CommonBasicStandardLibraries.Exceptions;
using Phase5DataLibrary.Models;
using System.Linq;
using System.Threading.Tasks;
using Phase5DataLibrary.Services;
namespace Phase5DataLibrary.ViewModels
{
    public class UnitViewModel : IUnitViewModel
    {
        private readonly IUnitService _unitService;
        private readonly ICalculateUnitStatService _calculatedUnitService;
        private readonly ITechViewModel _tech;
        private readonly CustomBasicList<string> _upgrades = new CustomBasicList<string>();
        private CustomBasicList<UpdateUnitStatModel> _fullAttackList = new CustomBasicList<UpdateUnitStatModel>();
        private CustomBasicList<UpdateUnitStatModel> _fullDefenseList = new CustomBasicList<UpdateUnitStatModel>();
        public UnitViewModel(IUnitService service, 
            ICalculateUnitStatService calculatedUnitService,
            ITechViewModel tech
            )
        {
            _unitService = service;
            _calculatedUnitService = calculatedUnitService;
            _tech = tech;
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
        public CustomBasicList<UpdateUnitStatModel> UnitAttackList { get; private set; } = new();
        public CustomBasicList<string> AttackUpgradeList { get; private set; } = new();
        public CustomBasicList<UpdateUnitStatModel> UnitDefenseList { get; private set; } = new();
        public CustomBasicList<string> DefenseUpgradeList { get; private set; } = new();
        public bool CanShowAttackTechs { get; private set; }
        public bool CanShowDefenseTechs { get; private set; }

        public async Task ChoseAttackUnitAsync()
        {
            if (string.IsNullOrWhiteSpace(AttackUnitRequested))
            {
                throw new BasicBlankException("Should not be allowd to get unit information because no unit was chosen");
            }
            CanShowAttackTechs = true;
            _tech.ClearAttackTechs();
            CustomBasicList<UnitModel> fullList = await _unitService.GetAttackUnitsAsync(AttackUnitRequested);
            _fullAttackList = _calculatedUnitService.GetCalculatedAttackUnits(fullList);
            if (_fullAttackList.Count == 0)
            {
                throw new BasicBlankException("Cannot have 0 units for attacking");
            }
            UnitAttackList = _fullAttackList.ToCustomBasicList();
            AttackCivilizations = UnitAttackList.GroupBy(xxx => xxx.BasicUnit.Civilization).Select(xxx => xxx.Key).OrderBy(xxx => xxx).ToCustomBasicList();
            if (UnitAttackList.Any(xxx => xxx.BasicUnit.Champion))
            {
                AttackUpgradeList = _upgrades.ToCustomBasicList();
            }
            else
            {
                AttackUpgradeList = new CustomBasicList<string>(); //because no need to select if no choices.
            }
            if (AttackCivilizations.Count == 1)
            {
                _tech.FilterAttackCivilization(AttackCivilizations.Single());
                AttackCivilizations = new CustomBasicList<string>(); //seems silly to choose civilzation if there is only one civilization.
            }
        }
        public async Task ChoseDefenseUnitAsync()
        {
            if (string.IsNullOrWhiteSpace(DefenseUnitRequested))
            {
                throw new BasicBlankException("Should not be allowd to get unit information because no unit was chosen");
            }
            _tech.ClearDefenseTechs();
            CanShowDefenseTechs = true;
            CustomBasicList<UnitModel> fullList = await _unitService.GetDefenseUnitsAsync(DefenseUnitRequested);
            _fullDefenseList = _calculatedUnitService.GetCalculatedDefenseUnits(fullList);
            if (_fullDefenseList.Count == 0)
            {
                throw new BasicBlankException("Cannot have 0 units for defense");
            }
            UnitDefenseList = _fullDefenseList.ToCustomBasicList();
            DefenseCivilizations = UnitDefenseList.GroupBy(xxx => xxx.BasicUnit.Civilization).Select(xxx => xxx.Key).OrderBy(xxx => xxx).ToCustomBasicList();
            if (UnitDefenseList.Any(xxx => xxx.BasicUnit.Champion))
            {
                DefenseUpgradeList = _upgrades.ToCustomBasicList();
            }
            else
            {
                DefenseUpgradeList = new CustomBasicList<string>(); //because no need to select if no choices.
            }
            if (DefenseCivilizations.Count == 1)
            {
                _tech.FilterDefenseCivilization(DefenseCivilizations.Single());
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
            //this is needed to also clear the techs to unselect all attack and defense techs.
            _tech.ClearAllTechs();
            _tech.UnselectAllAttackTechs();
            _tech.UnselectAllDefenseTechs();
            CanShowAttackTechs = false;
            CanShowDefenseTechs = false;
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
                    UnitAttackList.RemoveAllAndObtain(xxx => xxx.BasicUnit.Champion == false);
                    return;
                }
                if (AttackBaseString == "Base")
                {
                    UnitAttackList.RemoveAllAndObtain(xxx => xxx.BasicUnit.Champion); //should already do the filters
                    return;
                }
            }
            if (AttackBaseString == "Champion")
            {
                UnitAttackList = _fullAttackList.Where(xxx => xxx.BasicUnit.Champion).ToCustomBasicList();
                return;
            }
            if (AttackBaseString == "Base")
            {
                UnitAttackList = _fullAttackList.Where(xxx => xxx.BasicUnit.Champion == false).ToCustomBasicList();
                return;
            }
            throw new BasicBlankException($"Only Base And Chamption Are Supported, Not {AttackBaseString}");
        }
        public void FilterAttackCivilization()
        {
            _tech.ClearAttackTechs();
            UnitAttackList = _fullAttackList.Where(xxx => xxx.BasicUnit.Civilization == AttackCivilizationRequested).ToCustomBasicList();
            _calculatedUnitService.RecalculateAttackUnits(UnitAttackList); //i think it should recalculate just in case.
            _tech.FilterAttackCivilization(AttackCivilizationRequested); //this needed the tech view model so it can filter the tech list based on civilization chosen.
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
                    UnitDefenseList.RemoveAllAndObtain(xxx => xxx.BasicUnit.Champion == false);
                    return;
                }
                if (DefenseBaseString == "Base")
                {
                    UnitDefenseList.RemoveAllAndObtain(xxx => xxx.BasicUnit.Champion); //should already do the filters
                    return;
                }
            }
            if (DefenseBaseString == "Champion")
            {
                UnitDefenseList = _fullAttackList.Where(xxx => xxx.BasicUnit.Champion).ToCustomBasicList();
                return;
            }
            if (DefenseBaseString == "Base")
            {
                UnitDefenseList = _fullAttackList.Where(xxx => xxx.BasicUnit.Champion == false).ToCustomBasicList();
                return;
            }
            throw new BasicBlankException($"Only Base And Chamption Are Supported, Not {DefenseBaseString}");
        }
        public void FilterDefenseCivilization()
        {
            _tech.ClearDefenseTechs();
            UnitDefenseList = _fullDefenseList.Where(xxx => xxx.BasicUnit.Civilization == DefenseCivilizationRequested).ToCustomBasicList();
            _calculatedUnitService.RecalculateDefenseUnits(UnitDefenseList); //i think
            _tech.FilterDefenseCivilization(DefenseCivilizationRequested);
        }
        public async Task InitAsync()
        {
            AttackUnitStringList = await _unitService.GetAttackUnitsAsync(); //this part is still fine.
            DefenseUnitStringList = await _unitService.GetDefenseUnitsAsync();
        }
        public void RecalculateUnits()
        {
            if (UnitAttackList.Count > 0)
            {
                _calculatedUnitService.RecalculateAttackUnits(UnitAttackList);
            }
            if (UnitDefenseList.Count > 0)
            {
                _calculatedUnitService.RecalculateDefenseUnits(UnitDefenseList);
            }
        }
    }
}