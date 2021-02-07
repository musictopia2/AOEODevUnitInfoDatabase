using CommonBasicStandardLibraries.CollectionClasses;
using Phase5DataLibrary.Models;
using System.Threading.Tasks;
namespace Phase5DataLibrary.ViewModels
{
    public interface IUnitBaseViewModel
    {
        CustomBasicList<string> AttackUnitStringList { get; } //this would show up first now.
        CustomBasicList<string> DefenseUnitStringList { get; }
        string AttackUnitRequested { get; set; }
        string DefenseUnitRequested { get; set; }
        CustomBasicList<string> AttackCivilizations { get; } //based on unit selected.
        CustomBasicList<string> DefenseCivilizations { get; } //based on unit selected.
        string AttackCivilizationRequested { get; set; } //you have the right to request the civilization.
        string AttackBaseString { get; set; }
        string DefenseCivilizationRequested { get; set; } //you have the right to request the civilization.
        string DefenseBaseString { get; set; }
        CustomBasicList<UnitCalculatedModel> UnitAttackList { get; } //after choosing the unit.
        CustomBasicList<string> AttackUpgradeList { get; }
        CustomBasicList<UnitCalculatedModel> UnitDefenseList { get; } //after choosing the unit.
        CustomBasicList<string> DefenseUpgradeList { get; }
        Task InitAsync();
        void Clear(); //you have the ability to clear out to start over again.  clears both.
        Task ChoseAttackUnitAsync();
        void FilterAttackCivilization();
        void FilterAttackBaseChampion();
        Task ChoseDefenseUnitAsync();
        void FilterDefenseCivilization();
        void FilterDefenseBaseChampion();
        void RecalculateUnits(); //if choosing techs, needs to recalculate units.
    }
}