using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Back.Personas.Api.Services
{
    public static class StartupJwtConfigurationIdentity
    {

        public static void AddJwt(this IServiceCollection services, IConfiguration configuration)
        {
            string secretKey = configuration.GetValue<string>("jwt:secret");
            byte[] key = Encoding.UTF8.GetBytes(secretKey);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(
                x =>
                {
                    x.TokenValidationParameters = new()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = false,
                        ValidIssuer = "api:prueba",
                        ValidAudience = "https://doublevpartners.com/",
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(
                               secretKey
                            )
                        )

                    };
                });

        }

    }
}
