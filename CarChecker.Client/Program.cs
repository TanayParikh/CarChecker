using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using CarChecker.Components;
using CarChecker.Components.Data;

namespace CarChecker.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
            builder.Logging.SetMinimumLevel(LogLevel.Warning);

            builder.Services.AddCarCheckerComponents(builder.HostEnvironment.BaseAddress);
            builder.Services.AddSingleton<IVehicleReportOpener, VehicleReportOpener>();
            await builder.Build().RunAsync();
        }
    }
}
