using CommonBasicStandardLibraries.CollectionClasses;
using Microsoft.AspNetCore.Components;
using Phase2DataLibrary.Models;
namespace Phase2Site.Components
{
    public partial class UnitListComponent
    {

        [Parameter]
        public CustomBasicList<DefenseUnitModel> Units { get; set; }
    }
}