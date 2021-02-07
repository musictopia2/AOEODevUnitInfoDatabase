using CommonBasicStandardLibraries.CollectionClasses;
using Phase5DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phase5DataLibrary.Services
{
    public interface ITechService
    {
        Task<CustomBasicList<TechnologyModel>> GetAllAttackTechsAsync();
        Task<CustomBasicList<TechnologyModel>> GetAllDefenseTechsAsync();

    }
}
