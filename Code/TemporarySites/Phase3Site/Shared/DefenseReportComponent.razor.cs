using CommonBasicStandardLibraries.CollectionClasses;
using Microsoft.AspNetCore.Components;
using Phase3DataLibrary.Models;
using Phase3DataLibrary.Services;
using System.Threading.Tasks;
namespace Phase3Site.Shared
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