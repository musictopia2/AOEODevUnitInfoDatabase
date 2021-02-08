using CommonBasicStandardLibraries.CollectionClasses;
using Microsoft.AspNetCore.Components;
using Phase5DataLibrary.Models;
using Phase5DataLibrary.Services;
using Phase5DataLibrary.ViewModels;
using System.Threading.Tasks;
namespace Phase5Site.Shared
{
    public partial class AttackResultsReportComponent
    {
        [Inject]
        private IAttackResultsViewModel DataContext { get; set; }
        [Inject]
        private IUnitService UnitService { get; set; }
        private CustomBasicList<UpdateUnitStatModel> _startAttackList = new CustomBasicList<UpdateUnitStatModel>();
        private CustomBasicList<UpdateUnitStatModel> _startDefenseList = new CustomBasicList<UpdateUnitStatModel>();
        private CustomBasicList<AttackResultsModel> _resultsList = new CustomBasicList<AttackResultsModel>();
        [Inject]
        private ICalculateUnitStatService CalculateService { get; set; }
        protected override void OnInitialized()
        {
            
            base.OnInitialized();
        }
        protected override async Task OnInitializedAsync()
        {
            CustomBasicList<UnitModel> first = await UnitService.GetAllAttackUnitsAsync();

            _startAttackList = CalculateService.GetCalculatedAttackUnits(first);
            first = await UnitService.GetAllDefenseUnitsAsync();

            _startDefenseList = CalculateService.GetCalculatedDefenseUnits(first);
            _resultsList = DataContext.GetAttackResults(_startAttackList, _startDefenseList);
        }
    }
}