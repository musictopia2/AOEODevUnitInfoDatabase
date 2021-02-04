using CommonBasicStandardLibraries.CollectionClasses;
using Microsoft.AspNetCore.Components;
using Phase1DataLibrary.Models;
using Phase1DataLibrary.Services;
using System.Threading.Tasks;
namespace Phase1Site.Components
{
    public partial class UnitListComponent
    {
        [Parameter]
        public CustomBasicList<AttackUnitModel> Units { get; set; }


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