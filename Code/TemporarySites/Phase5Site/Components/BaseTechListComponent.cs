using Microsoft.AspNetCore.Components;
using Phase5DataLibrary.Containers;
using Phase5DataLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phase5Site.Components
{
    public abstract class BaseTechListComponent : ComponentBase
    {
        [Inject]
        protected TechListContainer Container { get; set; }
        [Inject]
        protected ITechViewModel DataContext { get; set; }
        protected override void OnInitialized()
        {
            DataContext.Refresh = () => StateHasChanged();
            base.OnInitialized();
        }
    }
}