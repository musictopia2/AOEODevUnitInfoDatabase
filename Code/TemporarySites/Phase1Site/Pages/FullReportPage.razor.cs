using Microsoft.AspNetCore.Components;
using System;
using System.Linq;
using System.Net.Http;

namespace Phase1Site.Pages
{
    public partial class FullReportPage
    {
        private readonly HttpClient Http;

        public FullReportPage()
        {
        }

        public FullReportPage(HttpClient httpClient) : this()
        {
            Http = httpClient;
        }
    }
}