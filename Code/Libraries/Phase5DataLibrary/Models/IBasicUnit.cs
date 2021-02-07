using CommonBasicStandardLibraries.CollectionClasses;
namespace Phase5DataLibrary.Models
{
    public interface IBasicUnit
    {
        //this is everything that is needed.
        bool IsAttacker { get; set; } //this means it can be used for attacking.
        bool Champion { get; set; }
        string UnitName { get; set; }
        string Civilization { get; set; }
        string Tags { get; set; }
        double BonusDamageProtection { get; set; }
        CustomBasicList<double> AnimationDurations { get; set; } //needed so the animation services can access it when it has the calculated ones.
    }
}