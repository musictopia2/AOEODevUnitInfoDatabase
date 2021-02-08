using CommonBasicStandardLibraries.CollectionClasses;
using Microsoft.AspNetCore.Components;
using Phase5DataLibrary.Models;
namespace Phase5Site.Components
{
    public partial class AttackUnitListComponent
    {
        [Parameter]
        public CustomBasicList<UpdateUnitStatModel> Units { get; set; }
    }
}