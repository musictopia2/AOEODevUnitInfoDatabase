using CommonBasicStandardLibraries.CollectionClasses;
using Microsoft.AspNetCore.Components;
using Phase4DataLibrary.Models;
using Phase4DataLibrary.Services;
using Phase4DataLibrary.ViewModels;
using System.Threading.Tasks;
namespace Phase4Site.Shared
{
    public partial class AttackResultsReportComponent
    {
        [Inject]
        private IAttackResultsViewModel DataContext { get; set; }
        [Inject]
        private IUnitService UnitService { get; set; }
        private CustomBasicList<UnitModel> _startAttackList = new CustomBasicList<UnitModel>();
        private CustomBasicList<UnitModel> _startDefenseList = new CustomBasicList<UnitModel>();
        private CustomBasicList<AttackResultsModel> _resultsList = new CustomBasicList<AttackResultsModel>();
        protected override async Task OnInitializedAsync()
        {
            await DataContext.InitAsync();
            _startAttackList = await UnitService.GetAllAttackUnitsAsync();
            _startDefenseList = await UnitService.GetAllDefenseUnitsAsync();
            _resultsList = DataContext.GetAttackResults(_startAttackList, _startDefenseList);
        }
    }
}