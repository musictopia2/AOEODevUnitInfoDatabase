using CommonBasicStandardLibraries.CollectionClasses;
using Microsoft.AspNetCore.Components;
using Phase1DataLibrary.Models;
using Phase1DataLibrary.Services;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Phase1Site.Components
{
    public partial class UnitListComponent
    {
        [Parameter]
        public CustomBasicList<AttackUnitModel> Units { get; set; }


        [Inject]
        private IAnimationService Service { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await Service.InitAsync();
        }

    }
}