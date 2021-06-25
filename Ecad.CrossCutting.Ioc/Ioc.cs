using ED.CrossCutting.Ioc.Resolvers;
using Microsoft.Extensions.DependencyInjection;

namespace ED.CrossCutting.Ioc
{
    public static class Ioc
    {
        public static IServiceCollection Resolvers(this IServiceCollection services)
        {
            services.ConfigureRepositories();

            return services;
        }
    }
}
