using CommonBasicStandardLibraries.CollectionClasses;
using Phase5DataLibrary.Models;
namespace Phase5DataLibrary.Containers
{
    public class TechListContainer
    {
        //this cannot have any defendencies.
        //this is like a model.
        public CustomBasicList<TechnologyModel> AttackSelectedTechList { get; set; } = new();
        public CustomBasicList<TechnologyModel> DefenseSelectedTechList { get; set; } = new(); //decided will not be read only anymore.
    }
}