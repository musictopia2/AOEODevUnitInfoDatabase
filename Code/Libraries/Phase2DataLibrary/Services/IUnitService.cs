using CommonBasicStandardLibraries.CollectionClasses;
using Phase2DataLibrary.Models;
using System.Threading.Tasks;
namespace Phase2DataLibrary.Services
{
    public interface IUnitService
    {
        Task<CustomBasicList<string>> GetUnitsAsync(); //only a list of strings this time.

        Task<CustomBasicList<DefenseUnitModel>> GetUnitsAsync(string unitRequested);

        Task<CustomBasicList<DefenseUnitModel>> GetAllUnitsAsync(); //this allows for a report to make sure everything is fine.
    }
}