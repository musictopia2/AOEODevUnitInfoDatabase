using CommonBasicStandardLibraries.CollectionClasses;
using Phase5DataLibrary.Models;
using System.Threading.Tasks;
namespace Phase5DataLibrary.Services
{
    //this is a data service.  something else has to do calculations.
    public interface IUnitService
    {
        Task<CustomBasicList<string>> GetAttackUnitsAsync(); //only a list of strings this time.
        Task<CustomBasicList<string>> GetDefenseUnitsAsync(); //only a list of strings this time.
        Task<CustomBasicList<UnitBaseModel>> GetAttackUnitsAsync(string unitRequested);
        Task<CustomBasicList<UnitBaseModel>> GetDefenseUnitsAsync(string unitRequested);
        Task<CustomBasicList<UnitBaseModel>> GetAllAttackUnitsAsync(); //this allows for a report to make sure everything is fine.
        Task<CustomBasicList<UnitBaseModel>> GetAllDefenseUnitsAsync(); //this allows for a report to make sure everything is fine.
    }
}