using CommonBasicStandardLibraries.CollectionClasses;
using Phase5DataLibrary.Models;
using System.Threading.Tasks;
namespace Phase5DataLibrary.ViewModels
{
    public interface ITechViewModel
    {

        //try to make this not require the unit view model.

        CustomBasicList<TechnologyModel> AttackSelectedTechList { get; }
        CustomBasicList<TechnologyModel> DefenseSelectedTechList { get; }
        CustomBasicList<TechnologyModel> AttackFullTechList { get; }
        CustomBasicList<TechnologyModel> DefenseFullTechList { get; }
        void SelectAllTech();
        void ClearTechs();
        Task InitAsync(); //this can be to get the lists.

        //i will have to see if anything else is needed.
        void FilterAttackingUnit(string attackingUnit);
        void FilterAttackCivilization(string civilization);
        Task FilterDefendingUnit(string defendingUnit);
        void FilterDefenseCivilization(string civilization);
    }
}
