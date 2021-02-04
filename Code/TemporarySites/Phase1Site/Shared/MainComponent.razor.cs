using BasicBlazorLibrary.Helpers;
using Microsoft.AspNetCore.Components;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Phase1Site.Shared
{
    public partial class MainComponent
    {
        private async Task NavigateToFullReportAsync()
        {
            await JS!.NavigateToOnAnotherTabAsync("FullReport");
        }
    }
}