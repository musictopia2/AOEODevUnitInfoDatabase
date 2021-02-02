using CommonBasicStandardLibraries.CollectionClasses;
using FirstDataModelLibrary;
using FirstSimpleDataSite.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FirstSimpleDataSite.Shared
{
    public partial class FirstComponent
    {
        [Inject]
        private IDataService Data { get; set; }

        private CustomBasicList<UpgradeModel> _upgrades = new CustomBasicList<UpgradeModel>();

        protected override async Task OnInitializedAsync()
        {
            _upgrades = await Data.GetUpgradesAsync();
        }
    }
}