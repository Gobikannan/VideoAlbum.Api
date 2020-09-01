using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VideoAlbum.Domain.Interfaces;
using VideoAlbum.Persistence.Repositories;

namespace VideoAlbum.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var dbConnectionString = configuration.GetConnectionString("MusicalogConnection");
            services.AddTransient<ISQLDatabaseContext, SQLDatabaseContext>(provider => new SQLDatabaseContext(dbConnectionString));
            services.AddScoped(typeof(IGenericDataRepository<>), typeof(GenericDataRepository<>));
            services.AddScoped<IAlbumRepository, AlbumRepository>();


            return services;
        }
    }
}
