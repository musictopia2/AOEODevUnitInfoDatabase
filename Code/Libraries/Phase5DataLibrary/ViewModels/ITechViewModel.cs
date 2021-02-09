using CommonBasicStandardLibraries.CollectionClasses;
using Phase5DataLibrary.Models;
using System;
using System.Threading.Tasks;
namespace Phase5DataLibrary.ViewModels
{
    public interface ITechViewModel
    {

        //try to make this not require the unit view model.
        //this can use the container.

        //for now, let the container handle it.

        CustomBasicList<TechnologyModel> AttackFullTechList { get; }
        CustomBasicList<TechnologyModel> DefenseFullTechList { get; }
        void SelectAllAttackTechs();
        void UnselectAllAttackTechs();

        void SelectAllDefenseTechs();
        void UnselectAllDefenseTechs();

        void ClearAllTechs(); //this means to reset the lists.

        void ClearAttackTechs();
        void ClearDefenseTechs();

        Task InitAsync(); //this can be to get the lists.

        //i will have to see if anything else is needed.
        //void FilterAttackingUnit(string attackingUnit);
        void FilterAttackCivilization(string civilization);
        //Task FilterDefendingUnit(string defendingUnit);
        void FilterDefenseCivilization(string civilization);
        Action Refresh { get; set; }
    }
}
