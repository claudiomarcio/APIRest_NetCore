using ED.Application.Interfaces;
using ED.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ED.CrossCutting.Ioc.Resolvers
{
    public static class AppServicesResolver
    {
        public static IServiceCollection ConfigureAppServices(this IServiceCollection services)
        {
            services.AddScoped<IEDAppService, EDAppService>();       
            return services;
        }
    }
}
