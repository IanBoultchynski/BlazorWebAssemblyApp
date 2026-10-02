using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace BlazorWebAssemblyApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            // Configuration du HttpClient pour appeler l'API
            // Configuration du HttpClient pour appeler l'API
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5171/") });

            // Enregistrement des ViewModels
            builder.Services.AddScoped<BlazorWebAssemblyApp.ViewModels.ProduitsViewModel>();
            builder.Services.AddScoped<BlazorWebAssemblyApp.ViewModels.MarquesViewModel>();

            // Enregistrement d'AutoMapper
            builder.Services.AddAutoMapper(cfg => cfg.AddProfile<BlazorWebAssemblyApp.Profiles.BlazorMappingProfile>());

            await builder.Build().RunAsync();
        }
    }
}
