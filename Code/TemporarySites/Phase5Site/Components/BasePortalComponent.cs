using Microsoft.AspNetCore.Components;
using Phase5DataLibrary.Containers;
using Phase5DataLibrary.ViewModels;

namespace Phase5Site.Components
{
    public abstract class BasePortalComponent : ComponentBase
    {
        [Inject]
        protected TechListContainer Container { get; set; }
        [Inject]
        protected ITechViewModel DataContext { get; set; }

        [Parameter]
        public EventCallback OnSave { get; set; }

        [Parameter]
        public EventCallback OnCancel { get; set; }
        
    }
}
