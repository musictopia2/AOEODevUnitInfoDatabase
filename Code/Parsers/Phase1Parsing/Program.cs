using CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.BasicExtensions;
using CommonBasicStandardLibraries.CollectionClasses;
using FirstDataModelLibrary;
using Phase1DataLibrary.Models;
using Phase1DataLibrary.Services;
using System.Linq;
using System.Threading.Tasks;
using fa = DataLocationLibrary.FileHelperClass;
using fs = CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.JsonSerializers.FileHelpers;
using ll = CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.FileFunctions.FileLocator;
namespace Phase1Parsing
{
    class Program
    {
        private readonly static string _phase1File = @"GameData\Phase1.json";
        private static string _phase1Path;
        private static string _oldSource;

        static async Task Main()
        {

            await PreparePhase1DataAsync();
            //for phase 1, assume only unit type are used.

            //await StartReportAsync();

        }
        //this proved i was able to get the report.
        static async Task StartReportAsync()
        {
            UnitService service = new UnitService();
            CustomBasicList<AttackUnitModel> units = await service.GetAllUnitsAsync();

        }

        static async Task PreparePhase1DataAsync()
        {
            fa.Setup();
            _phase1Path = ll.GetLocation(_phase1File);
            _oldSource = ll.GetLocation(fa.FirstParsedExcelDatabase);
            CustomBasicList<FullDatabaseModel> _fullList = await fs.RetrieveSavedObjectAsync<CustomBasicList<FullDatabaseModel>>(_oldSource);
            CustomBasicList<FullDatabaseModel> _filteredList = _fullList.Where(xxx => (xxx.Types == "Unit" || xxx.Types == "Damaging Building") && xxx.Champion == "Base").ToCustomBasicList();
            CustomBasicList<AttackUnitModel> _units = new CustomBasicList<AttackUnitModel>();
            _filteredList.ForEach(full =>
            {
                AttackUnitModel attack = new();
                attack.UnitName = full.Name;
                //attack.FullName = full.CompleteName;
                attack.AnimationDurations = Helpers.GetAnimations(full);
                attack.Civilization = full.Civ;
                if (full.Damagehand != "")
                {
                    attack.HandDPS = double.Parse(full.Damagehand);
                    //i am guessing only then do we have a list of damage animations for hand section.
                   
                }
                if (full.Damagecavalry != "")
                {
                    attack.CavalryDPS = double.Parse(full.Damagecavalry);

                }
                if (full.Damageranged != "")
                {
                    attack.RangedDPS = double.Parse(full.Damageranged);
                }
                
                if (full.Damagesiegerangedattack != "")
                {
                    attack.SiegeRangedDPS = double.Parse(full.Damagesiegerangedattack);
                }
                if (full.Damagesiegemeleeattack != "")
                {
                    attack.SiegeMeleeDPS = double.Parse(full.Damagesiegemeleeattack);
                }
                _units.Add(attack);
            });

            var list = _units.Where(xxx => xxx.HandDPS > 0 && xxx.SiegeMeleeDPS > 0).ToCustomBasicList();

            await fs.SaveObjectAsync(_phase1Path, _units);

        }

        



        //no need to create a library for parsing for phase 1 information.



    }
}
