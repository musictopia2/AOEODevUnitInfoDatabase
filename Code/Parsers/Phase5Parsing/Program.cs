using CommonBasicStandardLibraries.CollectionClasses;
using FirstDataModelLibrary;
using Phase5DataLibrary.Models;
using System.Threading.Tasks;
using fa = DataLocationLibrary.FileHelperClass;
using fs = CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.JsonSerializers.FileHelpers;
using ll = CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.FileFunctions.FileLocator;
namespace Phase5Parsing
{
    class Program
    {
        private readonly static string _phase5DatabaseFile = @"GameData\PhaseDatabase5.json";
        private static string _phase5DatabasePath;
        private readonly static string _phase5UpgradeFile = @"GameData\PhaseUpgrade5.json";
        private static string _phase5UpgradePath;
        private static string _oldDatabaseSource;
        private static string _oldUpgradeSource;
        static async Task Main()
        {
            await PreparePhase5DatabaseAsync();
            await PreparePhase5UpgradeAsync();
        }
        static async Task PreparePhase5UpgradeAsync()
        {
            fa.Setup();
            _phase5UpgradePath = ll.GetLocation(_phase5UpgradeFile);
            _oldUpgradeSource = ll.GetLocation(fa.FirstParsedExcelUpgrades);
            CustomBasicList<UpgradeModel> fullList = await fs.RetrieveSavedObjectAsync<CustomBasicList<UpgradeModel>>(_oldUpgradeSource);
            CustomBasicList<TechnologyModel> techs = new CustomBasicList<TechnologyModel>();
            fullList.ForEach(full =>
            {
                TechnologyModel tech = new();
                tech.Civilization = full.Civ;
                if (full.Cavalry2 != "")
                    tech.ArmorCavalry = double.Parse(full.Cavalry2);
                if (full.Infantry2 != "")
                    tech.ArmorHand = double.Parse(full.Infantry2);
                if (full.Ranged2 != "")
                    tech.ArmorRanged = double.Parse(full.Ranged2);
                if (full.Siege5 != "")
                    tech.ArmorSiege = double.Parse(full.Siege5);
                tech.Attack = full.Attack == "X";
                tech.Defense = full.Defense == "X";
                //has to be either attack or defense to showup.
                tech.Building = full.FromWhere;
                tech.Civilization = full.Civ;
                if (full.Damagecavalry != "")
                {
                    tech.CavalryDPS = double.Parse(full.Damagecavalry);
                }
                if (full.Ranged != "")
                {
                    tech.DamageBonusAbstractArcher = double.Parse(full.Ranged);
                }
                if (full.Siege != "")
                {
                    tech.DamageBonusAbstractArtillery = double.Parse(full.Siege);
                }
                if (full.Cavalry != "")
                    tech.DamageBonusAbstractCavalry = double.Parse(full.Cavalry);
                if (full.Infantry != "")
                    tech.DamageBonusAbstractInfantry = double.Parse(full.Infantry);
                if (full.Priest != "")
                    tech.DamageBonusAbstractPriest = double.Parse(full.Priest);
                if (full.Building != "")
                    tech.DamageBonusBuilding = double.Parse(full.Building);
                if (full.Sarissophoroi != "")
                    tech.DamageBonusGr_Cav_Sarissophoroi = double.Parse(full.Sarissophoroi);
                if (full.Ship != "")
                    tech.DamageBonusShip = double.Parse(full.Ship);
                if (full.Storehouse != "")
                    tech.DamageBonusUnitTypeBldgStorehouse = double.Parse(full.Storehouse);
                if (full.Villager == "25%")
                {
                    tech.DamageBonusUnitTypeVillager = .25;
                }
                else if (full.Villager != "")
                {
                    tech.DamageBonusUnitTypeVillager = double.Parse(full.Villager);
                }
                if (full.DamageMeleeinf != "")
                    tech.HandDPS = double.Parse(full.DamageMeleeinf);
                if (full.Hitpoints == "(-0,25)")
                {
                    tech.HitPoints = -.25;
                }
                else if (full.Hitpoints != "")
                {
                    tech.HitPoints = double.Parse(full.Hitpoints);
                }                    
                tech.Name = full.Name;
                if (full.Damageranged != "")
                    tech.RangedDPS = double.Parse(full.Damageranged);
                if (full.Damagesiegemeleeattack != "")
                    tech.SiegeMeleeDPS = double.Parse(full.Damagesiegemeleeattack);
                if (full.Damagesiegerangedattack != "")
                    tech.SiegeRangedDPS = double.Parse(full.Damagesiegerangedattack);
                if (tech.Attack || tech.Defense)
                {
                    techs.Add(tech);
                }
            });
            await fs.SaveObjectAsync(_phase5UpgradePath, techs);
        }
        static async Task PreparePhase5DatabaseAsync()
        {
            fa.Setup();
            _phase5DatabasePath = ll.GetLocation(_phase5DatabaseFile);
            _oldDatabaseSource = ll.GetLocation(fa.FirstParsedExcelDatabase);
            CustomBasicList<FullDatabaseModel> fullList = await fs.RetrieveSavedObjectAsync<CustomBasicList<FullDatabaseModel>>(_oldDatabaseSource);
            CustomBasicList<UnitModel> units = new CustomBasicList<UnitModel>();
            fullList.ForEach(full =>
            {
                UnitModel unit = new();
                unit.UnitName = full.Name;
                unit.Civilization = full.Civ;
                unit.Champion = full.Champion == "Champion";
                unit.Tags = full.Tags;
                unit.HitPoints = double.Parse(full.Colonne1);
                unit.ArmorCavalry = double.Parse(full.Armorcavalry);
                unit.ArmorHand = double.Parse(full.Armorhand);
                unit.ArmorRanged = double.Parse(full.Armorranged);
                unit.ArmorSiege = double.Parse(full.Armorsiege);
                unit.BonusDamageProtection = double.Parse(full.Bdp);
                unit.DamageBonusAbstractArcher = double.Parse(full.Damagebonusabstractarcher);
                unit.DamageBonusAbstractArtillery = double.Parse(full.Damagebonusabstractartillery);
                unit.DamageBonusAbstractCavalry = double.Parse(full.Damagebonusabstractcavalry);
                unit.DamageBonusAbstractInfantry = double.Parse(full.Damagebonusabstractinfantry);
                unit.DamageBonusAbstractPriest = double.Parse(full.Damagebonusabstractpriest);
                unit.DamageBonusBuilding = double.Parse(full.Damagebonusbuilding);
                unit.DamageBonusGr_Cav_Sarissophoroi = double.Parse(full.Damagebonusgr_cav_sarissophoroi);
                unit.DamageBonusShip = double.Parse(full.Damagebonusship);
                unit.DamageBonusUnitTypeBldgStorehouse = double.Parse(full.Damagebonusunittypebldgstorehouse);
                unit.DamageBonusUnitTypeVillager = double.Parse(full.Damagebonusunittypevillager1);
                if (full.Types == "Unit" || full.Tags == "Damaging Building")
                {
                    unit.IsAttacker = true;
                    unit.AnimationDurations = Helpers.GetAnimations(full);
                    if (full.Damagehand != "")
                    {
                        unit.HandDPS = double.Parse(full.Damagehand);
                    }
                    if (full.Damagecavalry != "")
                    {
                        unit.CavalryDPS = double.Parse(full.Damagecavalry);
                    }
                    if (full.Damageranged != "")
                    {
                        unit.RangedDPS = double.Parse(full.Damageranged);
                    }
                    if (full.Damagesiegerangedattack != "")
                    {
                        unit.SiegeRangedDPS = double.Parse(full.Damagesiegerangedattack);
                    }
                    if (full.Damagesiegemeleeattack != "")
                    {
                        unit.SiegeMeleeDPS = double.Parse(full.Damagesiegemeleeattack);
                    }
                    if (full.Name == "Palintonon" || full.Name == "LogThrower" || full.Name == "StoneThrower")
                    {
                        unit.SiegeMeleeDPS = 0;
                    }
                }
                else
                {
                    unit.IsAttacker = false;
                }
                if (unit.HitPoints > 0)
                {
                    units.Add(unit);
                }
            });
            await fs.SaveObjectAsync(_phase5DatabasePath, units);
        }
    }
}