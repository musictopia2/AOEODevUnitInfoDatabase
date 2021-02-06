using CommonBasicStandardLibraries.CollectionClasses;
using Microsoft.AspNetCore.Components;
using Phase4DataLibrary.Models;
namespace Phase4Site.Components
{
    public partial class AttackResultsUnitListComponent
    {
        [Parameter]
        public CustomBasicList<AttackResultsModel> Units { get; set; }
        //at this point, the processes had to already have ran.
        //this does not care whether its popup or not.
        //later can figure out the popup part.

    }
}