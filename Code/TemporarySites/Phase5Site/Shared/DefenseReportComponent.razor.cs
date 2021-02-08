using CommonBasicStandardLibraries.CollectionClasses;
using Microsoft.AspNetCore.Components;
using Phase5DataLibrary.Models;
using Phase5DataLibrary.Services;
using System.Threading.Tasks;
namespace Phase5Site.Shared
{
    public partial class DefenseReportComponent
    {
        [Inject]
        private IUnitService UnitService { get; set; }
        [Inject]
        private ICalculateUnitStatService CalculateService { get; set; }
        private CustomBasicList<UpdateUnitStatModel> _units = new CustomBasicList<UpdateUnitStatModel>();
        protected override async Task OnInitializedAsync()
        {
            var list = await UnitService.GetAllDefenseUnitsAsync();
            _units = CalculateService.GetCalculatedDefenseUnits(list); //hopefully the sorting is done automatically now (?)
        }
    }
}