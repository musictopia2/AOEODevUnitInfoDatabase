using CommonBasicStandardLibraries.CollectionClasses;
using Microsoft.AspNetCore.Components;
using Phase4DataLibrary.Models;
using Phase4DataLibrary.Services;
using System.Threading.Tasks;
namespace Phase4Site.Components
{
    public partial class AttackUnitListComponent
    {
        [Parameter]
        public CustomBasicList<UnitModel> Units { get; set; }
        [Inject]
        private IAnimationService AService { get; set; }
        [Inject] IDamageExceptionService DService { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await AService.InitAsync();
            await DService.InitAsync();
        }
    }
}