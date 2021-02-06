using CommonBasicStandardLibraries.CollectionClasses;
using FirstDataModelLibrary;
using Phase4DataLibrary.Models;
using System.Threading.Tasks;
using fa = DataLocationLibrary.FileHelperClass;
using fs = CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.JsonSerializers.FileHelpers;
using ll = CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.FileFunctions.FileLocator;
namespace Phase4Parsing
{
    class Program
    {
        private readonly static string _phase4File = @"GameData\Phase4.json";
        private static string _phase4Path;
        private static string _oldSource;
        static async Task Main()
        {
            await PreparePhase3DataAsync();
        }
        static async Task PreparePhase3DataAsync()
        {
            fa.Setup();
            _phase4Path = ll.GetLocation(_phase4File);
            _oldSource = ll.GetLocation(fa.FirstParsedExcelDatabase);
            CustomBasicList<FullDatabaseModel> _fullList = await fs.RetrieveSavedObjectAsync<CustomBasicList<FullDatabaseModel>>(_oldSource);
            CustomBasicList<FullDatabaseModel> fullList = await fs.RetrieveSavedObjectAsync<CustomBasicList<FullDatabaseModel>>(_oldSource);
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
                unit.DamageBonusAbstractinfantry = double.Parse(full.Damagebonusabstractinfantry);
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
            await fs.SaveObjectAsync(_phase4Path, units);
        }
    }
}