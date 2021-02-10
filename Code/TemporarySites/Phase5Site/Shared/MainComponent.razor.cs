using BasicBlazorLibrary.Components.ComboTextboxes;
using CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.BasicExtensions;
using CommonBasicStandardLibraries.CollectionClasses;
using Microsoft.AspNetCore.Components;
using Phase5DataLibrary.Containers;
using Phase5DataLibrary.Models;
using Phase5DataLibrary.ViewModels;
using System.Threading.Tasks;
using cc = CommonBasicStandardLibraries.BasicDataSettingsAndProcesses.SColorString;
namespace Phase5Site.Shared
{
    public partial class MainComponent
    {
        private ComboBoxStringList _firstAttackCombo;
        private ComboBoxStringList _secondAttackCombo;
        private ComboBoxStringList _thirdAttackCombo;
        //private ComboBoxStringList _firstDefenseCombo;
        private ComboBoxStringList _secondDefenseCombo;
        private ComboBoxStringList _thirdDefenseCombo;
        private bool _showAttackTechs;
        private bool _showDefenseTechs;
        private CustomBasicList<TechnologyModel> _oldAttackList = new();
        private CustomBasicList<TechnologyModel> _oldDefenseList = new();

        [Inject]
        private TechListContainer TechContainer { get; set; }

        [Inject]
        private ITechViewModel TechVM { get; set; }
        [Inject]
        private IUnitViewModel DataContext { get; set; }
        [Inject]
        private IAttackResultsViewModel ResultsContext { get; set; }
        private CustomBasicList<AttackResultsModel> _resultsList = new();
        private bool _focusedOnce = false;
        private readonly ComboStyleModel _style = new ComboStyleModel();
        protected override async Task OnInitializedAsync()
        {
            _firstAttackCombo = null;
            _secondAttackCombo = null;
            _thirdAttackCombo = null;
            //_firstDefenseCombo = null;
            _secondDefenseCombo = null;
            _thirdDefenseCombo = null;
            _style.Width = "250px";
            _style.HeaderBackgroundColor = cc.Black.ToWebColor();
            _style.HeaderTextColor = "#FBDAAF";
            _style.HighlightColor = _style.HeaderTextColor;
            _style.ComboBackgroundColor = cc.Transparent.ToWebColor();
            _style.ComboTextColor = cc.Black.ToWebColor();
            await DataContext.InitAsync();
            await TechVM.InitAsync();
        }
        protected override async Task OnAfterRenderAsync(bool firstRender) //this one is still true
        {
            if (_focusedOnce == false && _firstAttackCombo != null)
            {
                await _firstAttackCombo.GetTextBox.Value.FocusAsync();
                _focusedOnce = true;
            }
        }
        private async Task ChooseAttackUnitAsync()
        {
            await DataContext.ChoseAttackUnitAsync();
            if (DataContext.AttackCivilizations.Count > 0)
            {
                await _secondAttackCombo.GetTextBox.Value.FocusAsync();
            }
            else if (DataContext.AttackUpgradeList.Count > 0)
            {
                await _thirdAttackCombo.GetTextBox.Value.FocusAsync();
            }
        }
        private async Task ChooseDefenseUnitAsync()
        {
            await DataContext.ChoseDefenseUnitAsync();
            if (DataContext.DefenseCivilizations.Count > 0)
            {
                await _secondDefenseCombo.GetTextBox.Value.FocusAsync();
            }
            else if (DataContext.DefenseUpgradeList.Count > 0)
            {
                await _thirdDefenseCombo.GetTextBox.Value.FocusAsync();
            }
        }
        private async Task FilterAttackCivAsync()
        {
            DataContext.FilterAttackCivilization();
            if (DataContext.AttackUpgradeList.Count > 0)
            {
                await _thirdAttackCombo.GetTextBox.Value.FocusAsync();
            }
        }
        private async Task FilterDefenseCivAsync()
        {
            DataContext.FilterDefenseCivilization();
            if (DataContext.DefenseUpgradeList.Count > 0)
            {
                await _thirdDefenseCombo.GetTextBox.Value.FocusAsync();
            }
        }
        private async Task ClearAsync() //this is still true.
        {
            DataContext.Clear();
            _resultsList.Clear();
            await _firstAttackCombo.GetTextBox.Value.FocusAsync();
        }
        private void CloseReport()
        {
            _resultsList.Clear();
        }
        private void RunReportAsync()
        {
            _resultsList = ResultsContext.GetAttackResults(DataContext.UnitAttackList, DataContext.UnitDefenseList);
        }
        private void SaveAttackTechs()
        {
            _showAttackTechs = false;
            DataContext.RecalculateUnits();
        }
        private void SaveDefenseTechs()
        {
            _showDefenseTechs = false;
            DataContext.RecalculateUnits();
        }
        private void OpenAttackTechs()
        {
            _oldAttackList = TechContainer.AttackSelectedTechList.ToCustomBasicList();
            _showAttackTechs = true;
        }
        private void OpenDefenseTechs()
        {
            _oldDefenseList = TechContainer.DefenseSelectedTechList.ToCustomBasicList();
            _showDefenseTechs = true;
        }
        private void CancelAttackTechs()
        {
            TechContainer.AttackSelectedTechList = _oldAttackList.ToCustomBasicList();
            _showAttackTechs = false;
        }
        private void CancelDefenseTechs()
        {
            TechContainer.DefenseSelectedTechList = _oldDefenseList.ToCustomBasicList();
            _showDefenseTechs = false;
        }
    }
}