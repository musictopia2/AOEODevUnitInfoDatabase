using CommonBasicStandardLibraries.CollectionClasses;
using CommonBasicStandardLibraries.Exceptions;
using Phase1DataLibrary.Helpers;
using Phase1DataLibrary.Models;
using Phase1DataLibrary.Services;
using System.Linq;
using System.Threading.Tasks;
namespace Phase1DataLibrary.ViewModels
{
    public class UnitViewModel : IUnitViewModel
    {
        private readonly IUnitService _service;
        public UnitViewModel(IUnitService service)
        {
            _service = service;
        }
        public string CivilizationRequested { get; set; } = "";
        public string UnitRequested { get; set; } = "";
        public AttackUnitModel UnitUsed { get; set; }
        public EnumStage Stage { get; private set; }
        public CustomBasicList<string> Units { get; private set; }
        

        public CustomBasicList<string> Civilizations { get; private set; }
        public async Task ChoseCivilizationAsync()
        {
            if (string.IsNullOrWhiteSpace(CivilizationRequested))
            {
                throw new BasicBlankException("Should not allowed to populate the units because civilzation was not chosen");
            }
            Units = await _service.GetUnitsAsync(CivilizationRequested);
            Stage = EnumStage.ChooseUnit;
        }
        public async Task ChoseUnitAsync()
        {
            if (string.IsNullOrWhiteSpace(UnitRequested))
            {
                throw new BasicBlankException("Should not be allowd to get unit information because no unit was chosen");
            }
            UnitUsed = await _service.GetUnitInfoAsync(CivilizationRequested, UnitRequested);
            Stage = EnumStage.ShowResults;
        }
        public void Clear()
        {
            Stage = EnumStage.ChooseCiv;
            CivilizationRequested = "";
            UnitUsed = null;
            UnitRequested = "";
        }
        public async Task InitAsync()
        {
            Civilizations = await _service.GetCivilizationsAsync();
        }
    }
}