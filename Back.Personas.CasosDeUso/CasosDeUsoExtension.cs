using Back.Personas.CasosDeUso.Service;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;


namespace Back.Personas.CasosDeUso
{
    public static class CasosDeUsoExtension
    {
        public static void Aplicacion(this IServiceCollection services)
        {
            services
            .AddMediatR(op => op.RegisterServicesFromAssemblies(typeof(CasosDeUsoExtension).Assembly))
            .AddValidatorsFromAssembly(typeof(CasosDeUsoExtension).Assembly)
            .AddAutoMapper(typeof(CasosDeUsoExtension).Assembly);

            services.AddScoped<JwtService>();


        }
    }
}