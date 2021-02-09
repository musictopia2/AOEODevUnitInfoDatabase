using CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.BasicExtensions;
using CommonBasicStandardLibraries.CollectionClasses;
using CommonBasicStandardLibraries.Exceptions;
using Phase5DataLibrary.Models;
using System.Linq;
namespace Phase5DataLibrary.Helpers
{
    internal static class TechExtensions
    {
        public static void ApplyAttackTech(this UpdateUnitStatModel unit, TechnologyModel tech)
        {
            if (tech.HandDPS > 0)
            {
                unit.HandDPS = unit.HandDPS.MultiplyAndAdd(tech.HandDPS); //hopefully this simple (?)
            }
            if (tech.CavalryDPS > 0)
            {
                unit.CavalryDPS = unit.CavalryDPS.MultiplyAndAdd(tech.CavalryDPS);
            }    
            if (tech.RangedDPS > 0)
            {
                unit.RangedDPS = unit.RangedDPS.MultiplyAndAdd(tech.RangedDPS);
            }
            if (tech.SiegeMeleeDPS > 0)
            {
                unit.SiegeMeleeDPS = unit.SiegeMeleeDPS.MultiplyAndAdd(tech.SiegeMeleeDPS);
            }
            if (tech.SiegeRangedDPS > 0)
            {
                unit.SiegeRangedDPS = unit.SiegeRangedDPS.MultiplyAndAdd(tech.SiegeRangedDPS);
            }
            if (tech.DamageBonusAbstractArcher > 0)
            {
                unit.DamageBonusAbstractArcher = unit.DamageBonusAbstractArcher.MultiplyAndAdd(tech.DamageBonusAbstractArcher);
            }
            if (tech.DamageBonusAbstractArtillery > 0)
            {
                unit.DamageBonusAbstractArtillery = unit.DamageBonusAbstractArtillery.MultiplyAndAdd(tech.DamageBonusAbstractArtillery);
            }
            if (tech.DamageBonusAbstractCavalry > 0)
            {
                unit.DamageBonusAbstractCavalry = unit.DamageBonusAbstractCavalry.MultiplyAndAdd(tech.DamageBonusAbstractCavalry);
            }
            if (tech.DamageBonusAbstractInfantry > 0)
            {
                unit.DamageBonusAbstractInfantry = unit.DamageBonusAbstractInfantry.MultiplyAndAdd(tech.DamageBonusAbstractInfantry);
            }
            if (tech.DamageBonusAbstractPriest > 0)
            {
                unit.DamageBonusAbstractPriest = unit.DamageBonusAbstractPriest.MultiplyAndAdd(tech.DamageBonusAbstractPriest);
            }
            if (tech.DamageBonusBuilding > 0)
            {
                unit.DamageBonusBuilding = unit.DamageBonusBuilding.MultiplyAndAdd(tech.DamageBonusBuilding);
            }
            if (tech.DamageBonusGr_Cav_Sarissophoroi > 0)
            {
                unit.DamageBonusGr_Cav_Sarissophoroi = unit.DamageBonusGr_Cav_Sarissophoroi.MultiplyAndAdd(tech.DamageBonusGr_Cav_Sarissophoroi);
            }
            if (tech.DamageBonusShip > 0)
            {
                unit.DamageBonusShip = unit.DamageBonusShip.MultiplyAndAdd(tech.DamageBonusShip);
            }
            if (tech.DamageBonusUnitTypeBldgStorehouse > 0)
            {
                unit.DamageBonusUnitTypeBldgStorehouse = unit.DamageBonusUnitTypeBldgStorehouse.MultiplyAndAdd(tech.DamageBonusUnitTypeBldgStorehouse);
            }
            if (tech.DamageBonusUnitTypeVillager > 0)
            {
                unit.DamageBonusUnitTypeVillager = unit.DamageBonusUnitTypeVillager.MultiplyAndAdd(tech.DamageBonusUnitTypeVillager);
            }
        }
        public static void ApplyDefenseTech(this UpdateUnitStatModel unit, TechnologyModel tech)
        {
            if (tech.HitPoints > 0)
            {
                //this means to increase the hit points by the percentage shown.
                unit.HitPoints = unit.HitPoints.MultiplyAndAdd(tech.HitPoints);
            }
            if (tech.ArmorCavalry > 0)
            {
                unit.ArmorCavalry = unit.ArmorCavalry.ArmorUpgrades(tech.ArmorCavalry);
            }
            if (tech.ArmorHand > 0)
            {
                unit.ArmorHand = unit.ArmorHand.ArmorUpgrades(tech.ArmorHand);
            }
            if (tech.ArmorRanged > 0)
            {
                unit.ArmorRanged = unit.ArmorRanged.ArmorUpgrades(tech.ArmorRanged);
            }
            if (tech.ArmorSiege > 0)
            {
                unit.ArmorSiege = unit.ArmorSiege.ArmorUpgrades(tech.ArmorSiege);
            }
            //hopefully this is it.
        }

        public static void FilterTechCivs(this CustomBasicList<TechnologyModel> techs, string civilization)
        {
            techs.RemoveAllAndObtain(xxx =>
            {
                if (xxx.Civilization.ToLower() == "all")
                {
                    return false;
                }
                if (xxx.Civilization.ToLower() == civilization.ToLower())
                {
                    return false;
                }
                if (xxx.Civilization.Contains("-") == false)
                {
                    return true;
                }
                CustomBasicList<string> list = xxx.Civilization.Split("-").ToCustomBasicList();
                if (list.Count != 2)
                {
                    throw new BasicBlankException("Can only have 2 items for splitting -  Otherwise, rethink");
                }
                string excepts = list.Last();
                if (xxx.Civilization.ToLower() == excepts.ToLower())
                {
                    return true;
                }
                return false;
            });
        }
    }
}
