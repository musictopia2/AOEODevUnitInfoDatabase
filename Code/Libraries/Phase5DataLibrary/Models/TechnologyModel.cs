namespace Phase5DataLibrary.Models
{
    public class TechnologyModel
    {
        //decided to keep as class.
        //this is helpful for figuring out whether only certain civs, all civs or all except a certain civ.
        public string Civilization { get; set; } = "";
        public string Name { get; set; } = "";
        public string Building { get; set; } = ""; //can be wall as well.
        public bool Attack { get; set; }
        public bool Defense { get; set; }
        public double HandDPS { get; set; }
        public double CavalryDPS { get; set; }
        public double RangedDPS { get; set; }
        public double SiegeMeleeDPS { get; set; }
        public double SiegeRangedDPS { get; set; }
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
        public double HitPoints { get; set; } //will be by percent which means extra hit points.
        public double ArmorHand { get; set; }
        public double ArmorCavalry { get; set; }
        public double ArmorRanged { get; set; }
        public double ArmorSiege { get; set; }
    }
}