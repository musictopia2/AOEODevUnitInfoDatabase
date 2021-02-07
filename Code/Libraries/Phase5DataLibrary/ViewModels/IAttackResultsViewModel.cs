using CommonBasicStandardLibraries.CollectionClasses;
using Phase5DataLibrary.Models;
namespace Phase5DataLibrary.ViewModels
{
    public interface IAttackResultsViewModel
    {
        CustomBasicList<AttackResultsModel> GetAttackResults(CustomBasicList<UpdateUnitStatModel> attackingUnits, CustomBasicList<UpdateUnitStatModel> defendingUnits);
        //decided to be just one method.  this means if a report is needed, then whoever calls it is responsible for doing the list of attacking units and defending units.
        //no need for init since that part had to be initialized for the calculated model.
    }
}