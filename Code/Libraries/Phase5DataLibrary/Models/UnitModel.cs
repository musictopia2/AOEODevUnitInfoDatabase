using CommonBasicStandardLibraries.CollectionClasses;
namespace Phase5DataLibrary.Models
{
    /// <summary>
    /// this class now is just the base raw data.
    /// there now has to be another class which is the calculated one.
    /// not quite ready to do records.  there are lots of fields anyways.
    /// can eventually get from online sources.
    /// </summary>
    public class UnitModel : IBasicUnit, IOriginalUnit
    {
        public bool IsAttacker { get; set; } //this means it can be used for attacking.
        public bool Champion { get; set; }
        public string UnitName { get; set; } = "";
        public string Civilization { get; set; } = "";
        public CustomBasicList<double> AnimationDurations { get; set; } = new ();
        //maybe not needed anymore for base since i have another model now.
        public double HandDPS { get; set; }
        public double CavalryDPS { get; set; }
        public double RangedDPS { get; set; }
        public double SiegeMeleeDPS { get; set; }
        public double SiegeRangedDPS { get; set; }
        public double BonusDamageProtection { get; set; }
        //now the target type.
        public double HitPoints { get; set; }
        public double ArmorHand { get; set; }
        public double ArmorCavalry { get; set; }
        public double ArmorRanged { get; set; }
        public double ArmorSiege { get; set; }
        //now extras so the final calculations can be done.
        public string Tags { get; set; } = ""; //this is needed too now for the final calculations.
        public double DamageBonusAbstractInfantry { get; set; }
        public double DamageBonusAbstractArcher { get; set; }
        public double DamageBonusAbstractCavalry { get; set; }
        public double DamageBonusBuilding { get; set; }
        public double DamageBonusShip { get; set; }
        public double DamageBonusAbstractArtillery { get; set; }
        public double DamageBonusAbstractPriest { get; set; }
        public double DamageBonusUnitTypeVillager { get; set; }
        public double DamageBonusGr_Cav_Sarissophoroi { get; set; }
        public double DamageBonusUnitTypeBldgStorehouse { get; set; }
    }
}