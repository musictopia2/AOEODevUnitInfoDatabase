using Phase4DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Phase4DataLibrary.Helpers
{
    
    internal static class UnitExtensions
    {
        private static bool HasBonusDamage(this double amount)
        {
            if (amount == 1)
            {
                return false;
            }
            if (amount == 0)
            {
                return false;
            }
            return true;
        }

        public static EnumBonusCategory GetAttackBonusCategory(this UnitModel attackingUnit, UnitModel defendingUnit)
        {
            //first do the exceptions.
            if (attackingUnit.DamageBonusGr_Cav_Sarissophoroi.HasBonusDamage() && defendingUnit.UnitName == "Sarissophoroi")
            {
                return EnumBonusCategory.Saris;
            }
            if (attackingUnit.DamageBonusUnitTypeBldgStorehouse.HasBonusDamage() && defendingUnit.UnitName == "Storehouse")
            {
                return EnumBonusCategory.Storehouse;
            }
            if (attackingUnit.DamageBonusUnitTypeVillager.HasBonusDamage() && defendingUnit.Tags == "Villager")
            {
                return EnumBonusCategory.Villager;
            }
            if (attackingUnit.DamageBonusShip.HasBonusDamage() && defendingUnit.Tags == "Ship")
            {
                return EnumBonusCategory.Ship;
            }
            if (attackingUnit.DamageBonusBuilding.HasBonusDamage() && defendingUnit.Tags.ToLower().Contains("building"))
            {
                return EnumBonusCategory.Building;
            }
            if (attackingUnit.DamageBonusAbstractPriest.HasBonusDamage() && defendingUnit.Tags == "Priest")
            {
                return EnumBonusCategory.Priest;
            }
            if (attackingUnit.DamageBonusAbstractInfantry.HasBonusDamage() && defendingUnit.Tags == "Infantry")
            {
                return EnumBonusCategory.Infantry;
            }
            if (attackingUnit.DamageBonusAbstractCavalry.HasBonusDamage() && defendingUnit.Tags == "Cavalry")
            {
                return EnumBonusCategory.Cavalry;
            }
            if (attackingUnit.DamageBonusAbstractArtillery.HasBonusDamage() && defendingUnit.Tags.ToLower().Contains("siege"))
            {
                return EnumBonusCategory.Artillery;
            }
            if (attackingUnit.DamageBonusAbstractArcher.HasBonusDamage() && defendingUnit.Tags == "Ranged")
            {
                return EnumBonusCategory.Archer;
            }
            return EnumBonusCategory.None;
        }
        

        //hopefully siege melee is still siege armor.  that can be iffy.
        public static double GetArmorProtection(this UnitModel defendingUnit, EnumArmorCategory armor)
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
        public static double BonusDamagePercentage(this UnitModel attackingUnit, EnumBonusCategory category, UnitModel defendingUnit)
        {
            if (defendingUnit.BonusDamageProtection == 1)
            {
                return 1; //hopefully this will work (?)
            }
            //this does not care about armor.
            double raws = BonusAmountAlone(attackingUnit, category);
            if (raws == 1 || raws == 0)
            {
                return 1; //bonus damage protection means nothing if there is no bonus damage.
            }
            if (defendingUnit.BonusDamageProtection == 0)
            {
                return raws;
            }
            double output = raws * defendingUnit.BonusDamageProtection;
            return output;
        }
        private static double BonusAmountAlone(this UnitModel attackingUnit, EnumBonusCategory category)
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
