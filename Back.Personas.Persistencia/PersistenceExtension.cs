using Back.Personas.Persistencia.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Back.Personas.Persistencia
{
    public static class PersistenceExtension
    {
        public static void Persistencia(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AplicationDBContext>(options =>
            {
                var conexion = configuration.GetConnectionString("database");
                options.UseSqlServer(
                    conexion, sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(3, TimeSpan.FromSeconds(30), null);
                        sqlOptions.CommandTimeout(60);
                    }
                );
            });
        }

    }
}