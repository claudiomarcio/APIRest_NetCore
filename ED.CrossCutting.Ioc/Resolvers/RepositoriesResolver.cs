using ED.Domain.Data.Domain.Interfaces.Repository;
using ED.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ED.CrossCutting.Ioc.Resolvers
{
    public static class RepositoriesResolver
    {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IMusicRepository, MusicRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IGenderRepository, GenderRepository>();

            return services;

        }
    }
}
