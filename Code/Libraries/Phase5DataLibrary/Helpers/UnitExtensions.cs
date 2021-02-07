using Phase5DataLibrary.Models;
namespace Phase5DataLibrary.Helpers
{

    internal static class UnitExtensions
    {
        private static bool HasBonusDamage(this double amount)
        {
            if (amount == 1)
                return false;
            if (amount == 0)
                return false;
            return true;
        }

        public static EnumBonusCategory GetAttackBonusCategory(this UpdateUnitStatModel attackingUnit, UpdateUnitStatModel defendingUnit)
        {
            //first do the exceptions.
            if (attackingUnit.DamageBonusGr_Cav_Sarissophoroi.HasBonusDamage() && defendingUnit.BasicUnit.UnitName == "Sarissophoroi")
                return EnumBonusCategory.Saris;
            if (attackingUnit.DamageBonusUnitTypeBldgStorehouse.HasBonusDamage() && defendingUnit.BasicUnit.UnitName == "Storehouse")
                return EnumBonusCategory.Storehouse;
            if (attackingUnit.DamageBonusUnitTypeVillager.HasBonusDamage() && defendingUnit.BasicUnit.Tags == "Villager")
                return EnumBonusCategory.Villager;
            if (attackingUnit.DamageBonusShip.HasBonusDamage() && defendingUnit.BasicUnit.Tags == "Ship")
                return EnumBonusCategory.Ship;
            if (attackingUnit.DamageBonusBuilding.HasBonusDamage() && defendingUnit.BasicUnit.Tags.ToLower().Contains("building"))
                return EnumBonusCategory.Building;
            if (attackingUnit.DamageBonusAbstractPriest.HasBonusDamage() && defendingUnit.BasicUnit.Tags == "Priest")
                return EnumBonusCategory.Priest;
            if (attackingUnit.DamageBonusAbstractInfantry.HasBonusDamage() && defendingUnit.BasicUnit.Tags == "Infantry")
                return EnumBonusCategory.Infantry;
            if (attackingUnit.DamageBonusAbstractCavalry.HasBonusDamage() && defendingUnit.BasicUnit.Tags == "Cavalry")
                return EnumBonusCategory.Cavalry;
            if (attackingUnit.DamageBonusAbstractArtillery.HasBonusDamage() && defendingUnit.BasicUnit.Tags.ToLower().Contains("siege"))
                return EnumBonusCategory.Artillery;
            if (attackingUnit.DamageBonusAbstractArcher.HasBonusDamage() && defendingUnit.BasicUnit.Tags == "Ranged")
                return EnumBonusCategory.Archer;
            return EnumBonusCategory.None;
        }


        //hopefully siege melee is still siege armor.  that can be iffy.
        public static double GetArmorProtection(this UpdateUnitStatModel defendingUnit, EnumArmorCategory armor)
        {
            return armor switch
            {
                EnumArmorCategory.Cavalry => defendingUnit.ArmorCavalry,
                EnumArmorCategory.Hand => defendingUnit.ArmorHand,
                EnumArmorCategory.Ranged => defendingUnit.ArmorRanged,
                EnumArmorCategory.Siege => defendingUnit.ArmorSiege,
                _ => 0
            };
        }
        public static double BonusDamagePercentage(this UpdateUnitStatModel attackingUnit, EnumBonusCategory category, UpdateUnitStatModel defendingUnit)
        {
            if (defendingUnit.BasicUnit.BonusDamageProtection == 1)
                return 1; //hopefully this will work (?)
            //this does not care about armor.
            double raws = attackingUnit.BonusAmountAlone(category);
            if (raws == 1 || raws == 0)
                return 1; //bonus damage protection means nothing if there is no bonus damage.
            if (defendingUnit.BasicUnit.BonusDamageProtection == 0)
                return raws;
            double output = raws * defendingUnit.BasicUnit.BonusDamageProtection;
            return output;
        }
        private static double BonusAmountAlone(this UpdateUnitStatModel attackingUnit, EnumBonusCategory category)
        {
            return category switch
            {
                EnumBonusCategory.Archer => attackingUnit.DamageBonusAbstractArcher,
                EnumBonusCategory.Artillery => attackingUnit.DamageBonusAbstractArtillery,
                EnumBonusCategory.Building => attackingUnit.DamageBonusBuilding,
                EnumBonusCategory.Cavalry => attackingUnit.DamageBonusAbstractCavalry,
                EnumBonusCategory.Infantry => attackingUnit.DamageBonusAbstractInfantry,
                EnumBonusCategory.Priest => attackingUnit.DamageBonusAbstractPriest,
                EnumBonusCategory.Saris => attackingUnit.DamageBonusGr_Cav_Sarissophoroi,
                EnumBonusCategory.Ship => attackingUnit.DamageBonusShip,
                EnumBonusCategory.Storehouse => attackingUnit.DamageBonusUnitTypeBldgStorehouse,
                EnumBonusCategory.Villager => attackingUnit.DamageBonusUnitTypeVillager,
                _ => 1
            };
        }
    }
}
