using Microsoft.AspNetCore.Components;
using System;
using System.Linq;
using System.Net.Http;

namespace Phase5Site.Components
{
    public partial class DefenseTechPortal
    {
        private readonly HttpClient Http;

        public DefenseTechPortal()
        {
        }

        public DefenseTechPortal(HttpClient httpClient) : this()
        {
            Http = httpClient;
        }
    }
}