namespace Phase5DataLibrary.Models
{
    internal interface IOriginalUnit
    {
        double HandDPS { get; set; }
        double CavalryDPS { get; set; }
        double RangedDPS { get; set; }
        double SiegeMeleeDPS { get; set; }
        double SiegeRangedDPS { get; set; }
        double HitPoints { get; set; }
        double ArmorHand { get; set; }
        double ArmorCavalry { get; set; }
        double ArmorRanged { get; set; }
        double ArmorSiege { get; set; }
        double DamageBonusAbstractInfantry { get; set; }
        double DamageBonusAbstractArcher { get; set; }
        double DamageBonusAbstractCavalry { get; set; }
        double DamageBonusBuilding { get; set; }
        double DamageBonusShip { get; set; }
        double DamageBonusAbstractArtillery { get; set; }
        double DamageBonusAbstractPriest { get; set; }
        double DamageBonusUnitTypeVillager { get; set; }
        double DamageBonusGr_Cav_Sarissophoroi { get; set; }
        double DamageBonusUnitTypeBldgStorehouse { get; set; }
    }
}