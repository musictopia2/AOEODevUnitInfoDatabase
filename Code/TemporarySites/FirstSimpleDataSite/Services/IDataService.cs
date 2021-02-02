using CommonBasicStandardLibraries.CollectionClasses;
using FirstDataModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstSimpleDataSite.Services
{
    public interface IDataService
    {
        Task<CustomBasicList<FullDatabaseModel>> GetEntireDatabaseAsync();
        Task<CustomBasicList<UpgradeModel>> GetUpgradesAsync();
    }
}
