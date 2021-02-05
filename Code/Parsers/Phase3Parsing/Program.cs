using CommonBasicStandardLibraries.CollectionClasses;
using CommonBasicStandardLibraries.Exceptions;
using FirstDataModelLibrary;
using Phase3DataLibrary.Models;
using System.Linq;
using System.Threading.Tasks;
using fa = DataLocationLibrary.FileHelperClass;
using fs = CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.JsonSerializers.FileHelpers;
using ll = CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.FileFunctions.FileLocator;
namespace Phase3Parsing
{
    class Program
    {
        private readonly static string _phase3File = @"GameData\Phase3.json";
        private static string _phase3Path;
        private static string _oldSource;
        static async Task Main()
        {
            await PreparePhase3DataAsync();
        }
        static async Task PreparePhase3DataAsync()
        {
            fa.Setup();
            _phase3Path = ll.GetLocation(_phase3File);
            _oldSource = ll.GetLocation(fa.FirstParsedExcelDatabase);
            CustomBasicList<FullDatabaseModel> _fullList = await fs.RetrieveSavedObjectAsync<CustomBasicList<FullDatabaseModel>>(_oldSource);
            if (_fullList.Any(xxx => xxx.Name == "Champion") == false)
            {
                throw new BasicBlankException("Never showed champion in the original.  Rethink");
            }
            CustomBasicList<FullDatabaseModel> fullList = await fs.RetrieveSavedObjectAsync<CustomBasicList<FullDatabaseModel>>(_oldSource);
            CustomBasicList<UnitModel> units = new CustomBasicList<UnitModel>();
            fullList.ForEach(full =>
            {
                UnitModel unit = new();
                unit.UnitName = full.Name;
                unit.Civilization = full.Civ;
                unit.Champion = full.Champion == "Champion";
                unit.HitPoints = double.Parse(full.Colonne1); //i think.
                unit.ArmorCavalry = double.Parse(full.Armorcavalry);
                unit.ArmorHand = double.Parse(full.Armorhand);
                unit.ArmorRanged = double.Parse(full.Armorranged);
                unit.ArmorSiege = double.Parse(full.Armorsiege);
                if (full.Types == "Unit" || full.Tags == "Damaging Building")
                {
                    unit.IsAttacker = true;
                    unit.AnimationDurations = Helpers.GetAnimations(full);
                    if (full.Damagehand != "")
                    {
                        unit.HandDPS = double.Parse(full.Damagehand);
                        //i am guessing only then do we have a list of damage animations for hand section.

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
            await fs.SaveObjectAsync(_phase3Path, units);
        }
    }
}
