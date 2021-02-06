using CommonBasicStandardLibraries.CollectionClasses;
using Microsoft.AspNetCore.Components;
using Phase4DataLibrary.Models;
namespace Phase4Site.Components
{
    public partial class DefenseUnitListComponent
    {
        [Parameter]
        public CustomBasicList<UnitModel> Units { get; set; }
    }
}