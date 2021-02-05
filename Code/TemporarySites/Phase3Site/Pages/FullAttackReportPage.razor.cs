using Microsoft.AspNetCore.Components;
using System;
using System.Linq;
using System.Net.Http;

namespace Phase3Site.Pages
{
    public partial class FullAttackReportPage
    {
        private readonly HttpClient Http;

        public FullAttackReportPage()
        {
        }

        public FullAttackReportPage(HttpClient httpClient) : this()
        {
            Http = httpClient;
        }
    }
}