using CommonBasicStandardLibraries.CollectionClasses;
using Microsoft.AspNetCore.Components;
using Phase5DataLibrary.Models;
namespace Phase5Site.Components
{
    public partial class AttackResultsUnitListComponent
    {
        [Parameter]
        public CustomBasicList<AttackResultsModel> Units { get; set; }
    }
}