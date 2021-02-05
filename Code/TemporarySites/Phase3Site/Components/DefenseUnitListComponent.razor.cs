using CommonBasicStandardLibraries.CollectionClasses;
using Microsoft.AspNetCore.Components;
using Phase3DataLibrary.Models;
namespace Phase3Site.Components
{
    public partial class DefenseUnitListComponent
    {
        [Parameter]
        public CustomBasicList<UnitModel> Units { get; set; }
    }
}