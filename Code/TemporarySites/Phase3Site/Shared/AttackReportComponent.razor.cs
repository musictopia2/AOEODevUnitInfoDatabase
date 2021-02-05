using CommonBasicStandardLibraries.CollectionClasses;
using Microsoft.AspNetCore.Components;
using Phase3DataLibrary.Models;
using Phase3DataLibrary.Services;
using System.Threading.Tasks;
namespace Phase3Site.Shared
{
    public partial class AttackReportComponent
    {
        [Inject]
        private IUnitService UnitService { get; set; }
        private CustomBasicList<UnitModel> _units = new CustomBasicList<UnitModel>();

        protected override async Task OnInitializedAsync()
        {
            _units = await UnitService.GetAllAttackUnitsAsync(); //hopefully the sorting is done automatically now (?)
        }
    }
}