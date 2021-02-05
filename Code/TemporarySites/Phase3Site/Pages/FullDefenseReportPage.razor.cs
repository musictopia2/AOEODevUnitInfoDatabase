using Microsoft.AspNetCore.Components;
using System;
using System.Linq;
using System.Net.Http;

namespace Phase3Site.Pages
{
    public partial class FullDefenseReportPage
    {
        private readonly HttpClient Http;

        public FullDefenseReportPage()
        {
        }

        public FullDefenseReportPage(HttpClient httpClient) : this()
        {
            Http = httpClient;
        }
    }
}