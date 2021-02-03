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
        //does not care where it gets the list of civilizations.
        Task<CustomBasicList<string>> GetCivilizationsAsync();

        Task<CustomBasicList<string>> GetUnitsAsync(string civilzation);

        Task<AttackUnitModel> GetUnitInfoAsync(string civilization, string unitRequested);

    }
}
