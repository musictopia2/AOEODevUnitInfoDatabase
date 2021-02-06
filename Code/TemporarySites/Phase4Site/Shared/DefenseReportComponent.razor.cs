using CommonBasicStandardLibraries.CollectionClasses;
using Microsoft.AspNetCore.Components;
using Phase4DataLibrary.Models;
using Phase4DataLibrary.Services;
using System.Threading.Tasks;
namespace Phase4Site.Shared
{
    public partial class DefenseReportComponent
    {
        [Inject]
        private IUnitService UnitService { get; set; }
        private CustomBasicList<UnitModel> _units = new CustomBasicList<UnitModel>();

        protected override async Task OnInitializedAsync()
        {
            _units = await UnitService.GetAllDefenseUnitsAsync(); //hopefully the sorting is done automatically now (?)
        }
    }
}