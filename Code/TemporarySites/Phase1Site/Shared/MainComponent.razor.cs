using BasicBlazorLibrary.Components.ComboTextboxes;
using BasicBlazorLibrary.Helpers;
using CommonBasicStandardLibraries.CollectionClasses;
using Microsoft.AspNetCore.Components;
using Phase1DataLibrary.Models;
using Phase1DataLibrary.Services;
using Phase1DataLibrary.ViewModels;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Phase1Site.Shared
{
    public partial class MainComponent
    {

        private ComboBoxStringList _firstCombo;
        private ComboBoxStringList _secondCombo;

        [Inject]
        private IUnitViewModel DataContext { get; set; }

        private bool _focusedOnce = false;

        private readonly ComboStyleModel _style = new ComboStyleModel();

        protected override async Task OnInitializedAsync()
        {
            _firstCombo = null;
            _secondCombo = null;
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
            await _secondCombo.GetTextBox.Value.FocusAsync();
        }
        private async Task ClearAsync()
        {
            DataContext.Clear();
            await _firstCombo.GetTextBox.Value.FocusAsync();
        }
        
    }
}