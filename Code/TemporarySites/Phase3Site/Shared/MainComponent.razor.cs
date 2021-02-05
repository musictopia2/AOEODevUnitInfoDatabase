using BasicBlazorLibrary.Components.ComboTextboxes;
using BasicBlazorLibrary.Helpers;
using Microsoft.AspNetCore.Components;
using Phase3DataLibrary.ViewModels;
using System.Threading.Tasks;
namespace Phase3Site.Shared
{
    public partial class MainComponent
    {
        private ComboBoxStringList _firstAttackCombo;
        private ComboBoxStringList _secondAttackCombo;
        private ComboBoxStringList _thirdAttackCombo;

        //private ComboBoxStringList _firstDefenseCombo;
        private ComboBoxStringList _secondDefenseCombo;
        private ComboBoxStringList _thirdDefenseCombo;


        [Inject]
        private IUnitViewModel DataContext { get; set; }
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
            _style.Width = "150px";
            await DataContext.InitAsync();
        }
        protected override async Task OnAfterRenderAsync(bool firstRender) //this one is still true
        {
            if (_focusedOnce == false && _firstAttackCombo != null)
            {
                await _firstAttackCombo.GetTextBox.Value.FocusAsync();
                _focusedOnce = true;
            }
        }

        private async Task NavigateToAttackFullReportAsync()
        {
            await JS!.NavigateToOnAnotherTabAsync("FullAttackReportPage");
        }
        private async Task NavigateToDefenseFullReportAsync()
        {
            await JS!.NavigateToOnAnotherTabAsync("FullDefenseReportPage");
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
            await _firstAttackCombo.GetTextBox.Value.FocusAsync();
        }
    }
}