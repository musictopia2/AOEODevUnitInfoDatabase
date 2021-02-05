using CommonBasicStandardLibraries.CollectionClasses;
using Phase2DataLibrary.Models;
using System.Threading.Tasks;
namespace Phase2DataLibrary.ViewModels
{
    public interface IUnitViewModel
    {
        CustomBasicList<string> UnitStringList { get; } //this would show up first now.
        string UnitRequested { get; set; }
        CustomBasicList<string> Civilizations { get; } //based on unit selected.
        string CivilizationRequested { get; set; } //you have the right to request the civilization.
        string BaseString { get; set; }
        CustomBasicList<DefenseUnitModel> UnitDefenseList { get; } //after choosing the unit.
        CustomBasicList<string> UpgradeList { get; }
        Task InitAsync();
        void Clear(); //you have the ability to clear out to start over again.
        Task ChoseUnitAsync();
        void FilterCivilization();
        void FilterBaseChampion();
    }
}