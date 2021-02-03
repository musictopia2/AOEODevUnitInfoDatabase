using CommonBasicStandardLibraries.CollectionClasses;
using Phase1DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phase1DataLibrary.Services
{
    public interface IUnitService
    {

        Task<CustomBasicList<string>> GetUnitsAsync(); //only a list of strings this time.

        Task<CustomBasicList<AttackUnitModel>> GetUnitsAsync(string unitRequested);

        Task<CustomBasicList<AttackUnitModel>> GetAllUnitsAsync(); //this allows for a report to make sure everything is fine.


        //does not care where it gets the list of civilizations.
        //Task<CustomBasicList<string>> GetCivilizationsAsync();

        //Task<CustomBasicList<string>> GetUnitsAsync(string civilzation);

        //Task<AttackUnitModel> GetUnitInfoAsync(string civilization, string unitRequested);

    }
}
