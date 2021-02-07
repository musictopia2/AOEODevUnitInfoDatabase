namespace Phase5DataLibrary.Models
{
    /// <summary>
    /// this is intended to show the final results.
    /// the purpose of doing this way is so i don't have to calculate the same stuff over and over.  should do just once.
    /// </summary>
    public class UpdateUnitStatModel
    {
        public string FullName => BasicUnit.Champion == false ? $"{BasicUnit.Civilization} {BasicUnit.UnitName}" : $"{BasicUnit.Civilization} {BasicUnit.UnitName} Champion"; //this means it can do other parts this time.
        internal static EnumArmorCategory GetDefenseArmorCategory(EnumDamageType damageCategory) //belongs here.
        {
            return damageCategory switch
            {
                EnumDamageType.Cavaltry => EnumArmorCategory.Cavalry,
                EnumDamageType.Hand => EnumArmorCategory.Hand,
                EnumDamageType.Ranged => EnumArmorCategory.Ranged,
                _ => EnumArmorCategory.Siege
            };
        }

        public IBasicUnit BasicUnit { get; set; }
        //this will not care about original damage.  since this is the calculated version.
        public double HandDPS { get; set; }
        public double CavalryDPS { get; set; }
        public double RangedDPS { get; set; }
        public double SiegeMeleeDPS { get; set; }
        public double SiegeRangedDPS { get; set; }
        public double HitPoints { get; set; }
        public double ArmorHand { get; set; }
        public double ArmorCavalry { get; set; }
        public double ArmorRanged { get; set; }
        public double ArmorSiege { get; set; }
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
        public double HandDPA { get; set; }
        public double CavalryDPA { get; set; }
        public double RangedDPA { get; set; }
        public double SiegeMeleeDPA { get; set; }
        public double SiegeRangedDPA { get; set; }
    }
}