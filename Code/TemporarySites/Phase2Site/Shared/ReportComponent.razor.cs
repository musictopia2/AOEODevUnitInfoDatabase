using CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.BasicExtensions;
using CommonBasicStandardLibraries.CollectionClasses;
using Microsoft.AspNetCore.Components;
using Phase2DataLibrary.Models;
using Phase2DataLibrary.Services;
using System.Linq;
using System.Threading.Tasks;
namespace Phase2Site.Shared
{
    public partial class ReportComponent
    {
        [Inject]
        private IUnitService UnitService { get; set; }
        private CustomBasicList<DefenseUnitModel> _units = new CustomBasicList<DefenseUnitModel>();
        protected override async Task OnInitializedAsync()
        {
            _units = await UnitService.GetAllUnitsAsync();
            _units = _units.OrderBy(xxx => xxx.FullName).ToCustomBasicList();
        }
    }
}