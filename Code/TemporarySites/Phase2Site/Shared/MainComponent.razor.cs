using BasicBlazorLibrary.Components.ComboTextboxes;
using BasicBlazorLibrary.Helpers;
using Microsoft.AspNetCore.Components;
using Phase2DataLibrary.ViewModels;
using System.Threading.Tasks;
namespace Phase2Site.Shared
{
    public partial class MainComponent
    {
        private ComboBoxStringList _firstCombo;
        private ComboBoxStringList _secondCombo;
        private ComboBoxStringList _thirdCombo;
        [Inject]
        private IUnitViewModel DataContext { get; set; }
        private bool _focusedOnce = false;
        private readonly ComboStyleModel _style = new ComboStyleModel();
        protected override async Task OnInitializedAsync()
        {
            _firstCombo = null;
            _secondCombo = null;
            _thirdCombo = null;
            _style.Width = "150px";
            await DataContext.InitAsync();
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (_focusedOnce == false && _firstCombo != null)
            {
                await _firstCombo.GetTextBox.Value.FocusAsync();
                _focusedOnce = true;
            }
        }
        private async Task NavigateToFullReportAsync()
        {
            await JS!.NavigateToOnAnotherTabAsync("FullReport");
        }
        private async Task ChooseUnitAsync()
        {
            await DataContext.ChoseUnitAsync();
            if (DataContext.Civilizations.Count > 0)
            {
                await _secondCombo.GetTextBox.Value.FocusAsync();
            }
            else if (DataContext.UpgradeList.Count > 0)
            {
                await _thirdCombo.GetTextBox.Value.FocusAsync();
            }
        }
        private async Task FilterCivAsync()
        {
            DataContext.FilterCivilization();
            if (DataContext.UpgradeList.Count > 0)
            {
                await _thirdCombo.GetTextBox.Value.FocusAsync();
            }
        }
        private async Task ClearAsync()
        {
            DataContext.Clear();
            await _firstCombo.GetTextBox.Value.FocusAsync();
        }
    }
}