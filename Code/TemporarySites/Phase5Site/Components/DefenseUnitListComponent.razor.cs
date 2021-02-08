using CommonBasicStandardLibraries.CollectionClasses;
using Microsoft.AspNetCore.Components;
using Phase5DataLibrary.Models;
namespace Phase5Site.Components
{
    public partial class DefenseUnitListComponent
    {
        [Parameter]
        public CustomBasicList<UpdateUnitStatModel> Units { get; set; }
    }
}