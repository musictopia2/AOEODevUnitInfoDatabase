using CommonBasicStandardLibraries.CollectionClasses;
using Phase4DataLibrary.Models;
namespace Phase4DataLibrary.ViewModels
{
    public interface IAttackResultsViewModel
    {
        CustomBasicList<AttackResultsModel> GetAttackResults(CustomBasicList<UnitModel> attackingUnits, CustomBasicList<UnitModel> defendingUnits);
        //decided to be just one method.  this means if a report is needed, then whoever calls it is responsible for doing the list of attacking units and defending units.

    }
}