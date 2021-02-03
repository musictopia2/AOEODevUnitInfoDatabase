using CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.BasicExtensions;
using CommonBasicStandardLibraries.CollectionClasses;
using Microsoft.AspNetCore.Components;
using Phase1DataLibrary.Models;
using Phase1DataLibrary.Services;
using System.Linq;
using System.Threading.Tasks;
namespace Phase1Site.Shared
{
    public partial class ReportComponent
    {
        [Inject]
        private IUnitService UnitService { get; set; }
        [Inject]
        private IAnimationService AnimationService { get; set; }
        private CustomBasicList<AttackUnitModel> _units = new CustomBasicList<AttackUnitModel>();
        protected override async Task OnInitializedAsync()
        {
            _units = await UnitService.GetAllUnitsAsync();
            _units = _units.OrderBy(xxx => xxx.FullName).ToCustomBasicList();
        }
    }
}