using CarChecker.Components.Data;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace CarChecker.Components
{
    public static class CarCheckerComponentsServiceCollectionExtensions
    {
        public static IServiceCollection AddCarCheckerComponents(this IServiceCollection services, string baseAddress)
        {
            // Configure HttpClient for use when talking to server backend
            services.AddHttpClient("CarChecker.ServerAPI",
                client => client.BaseAddress = new Uri(baseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
            services.AddTransient(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("CarChecker.ServerAPI"));        
            services.AddApiAuthorization();
            services.AddScoped<AccountClaimsPrincipalFactory<RemoteUserAccount>, OfflineAccountClaimsPrincipalFactory>();
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddScoped<LocalVehiclesStore>();
            return services;
        }
    }
}
