using CommonBasicStandardLibraries.CollectionClasses;
using FirstDataModelLibrary;
using Phase2DataLibrary.Models;
using System.Threading.Tasks;
using fa = DataLocationLibrary.FileHelperClass;
using fs = CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.JsonSerializers.FileHelpers;
using ll = CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.FileFunctions.FileLocator;
namespace Phase2Parsing
{
    class Program
    {
        private readonly static string _phase2File = @"GameData\Phase2.json";
        private static string _phase2Path;
        private static string _oldSource;
        static async Task Main()
        {
            await PreparePhase2DataAsync();
        }
        static async Task PreparePhase2DataAsync()
        {
            //based on work for phase 1, decided that champion for now will just use the old data from excel.
            //can later decide if we do something advanced.  may require rethinking.
            //if i had to do this first, i may not have made it this far though.
            fa.Setup();
            _phase2Path = ll.GetLocation(_phase2File);
            _oldSource = ll.GetLocation(fa.FirstParsedExcelDatabase);
            CustomBasicList<FullDatabaseModel> fullList = await fs.RetrieveSavedObjectAsync<CustomBasicList<FullDatabaseModel>>(_oldSource);
            CustomBasicList<DefenseUnitModel> _units = new CustomBasicList<DefenseUnitModel>();
            fullList.ForEach(full =>
            {
                DefenseUnitModel defense = new();
                defense.UnitName = full.Name;
                defense.Civilization = full.Civ;
                defense.Champion = full.Champion == "Champion";
                defense.HitPoints = double.Parse(full.Colonne1); //i think.
                defense.ArmorCavalry = double.Parse(full.Armorcavalry);
                defense.ArmorHand = double.Parse(full.Armorhand);
                defense.ArmorRanged = double.Parse(full.Armorranged);
                defense.ArmorSiege = double.Parse(full.Armorsiege);
                if (defense.HitPoints > 0)
                {
                    _units.Add(defense); //if the hit points is 0, then cannot do i think.
                }
            });
            await fs.SaveObjectAsync(_phase2Path, _units);
        }
    }
}