namespace Phase4DataLibrary.Models
{
    public class AttackResultsModel
    {
        public string DamageTypeString { get; set; } = "";
        public double TrueDPA { get; set; }
        //this means if somebody has more than one attack, then will be another entry.
        public double NumberOfAnimations { get; set; } //the more required the longer it takes to kill it.
        public string AttackingUnit { get; set; } = "";
        public string DefendingUnit { get; set; } = ""; //this will be the full unit including civ and whether its champion.
    }
}