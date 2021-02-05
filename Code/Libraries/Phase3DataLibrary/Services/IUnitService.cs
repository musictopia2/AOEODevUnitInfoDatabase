using CommonBasicStandardLibraries.CollectionClasses;
using Phase3DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Phase3DataLibrary.Services
{
    public interface IUnitService
    {
        Task<CustomBasicList<string>> GetAttackUnitsAsync(); //only a list of strings this time.
        Task<CustomBasicList<string>> GetDefenseUnitsAsync(); //only a list of strings this time.
        Task<CustomBasicList<UnitModel>> GetAttackUnitsAsync(string unitRequested);
        Task<CustomBasicList<UnitModel>> GetDefenseUnitsAsync(string unitRequested);
        Task<CustomBasicList<UnitModel>> GetAllAttackUnitsAsync(); //this allows for a report to make sure everything is fine.
        Task<CustomBasicList<UnitModel>> GetAllDefenseUnitsAsync(); //this allows for a report to make sure everything is fine.
    }
}