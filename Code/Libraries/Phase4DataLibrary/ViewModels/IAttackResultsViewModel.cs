using CommonBasicStandardLibraries.CollectionClasses;
using Phase4DataLibrary.Models;
namespace Phase4DataLibrary.ViewModels
{
    public interface IAttackResultsViewModel
    {
        CustomBasicList<AttackResultsModel> GetAttackResults(CustomBasicList<UnitModel> attackingUnits, CustomBasicList<UnitModel> defendingUnits);
        CustomBasicList<AttackResultsModel> GetAttackResults(); //this will be the full report.
    }
}