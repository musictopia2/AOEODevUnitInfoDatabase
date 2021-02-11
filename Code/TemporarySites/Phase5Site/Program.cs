using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Phase5DataLibrary.Containers;
using Phase5DataLibrary.Services;
using Phase5DataLibrary.ViewModels;
using System;
using System.Net.Http;
using System.Threading.Tasks;
namespace Phase5Site
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddSingleton<IUnitService, UnitService>(); //for now, this should be fine.
            builder.Services.AddSingleton<ITechService, TechService>();
            builder.Services.AddSingleton<IAnimationService, AnimationService>();
            builder.Services.AddSingleton<IDamageExceptionService, DamageExceptionService>();
            //can't do the unitviewmodel until something handles the stats.
            //since this has to communicate with the stats now.
            builder.Services.AddScoped<IUnitViewModel, UnitViewModel>();
            builder.Services.AddScoped<IAttackResultsViewModel, AttackResultsViewModel>();
            builder.Services.AddScoped<ICalculateUnitStatService, CalculateUnitStatService>();
            builder.Services.AddScoped<TechListContainer, TechListContainer>();
            builder.Services.AddScoped<ITechViewModel, TechViewModel>();
            await builder.Build().RunAsync();
        }
    }
}