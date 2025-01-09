using System.Text;
using data_access;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using models.Utils;
using services.Implementations;
using services.Interfaces;

namespace vehicle_management_api.Helpers
{
    public class GlobalServices
    {
        public static void AddDefaultServices(WebApplicationBuilder builder)
        {
            // add controllers and add model validation exception handler
            builder.Services.AddControllers()
            .ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                    throw new Exception();
            });
            builder.Services.AddEndpointsApiExplorer();
        }

        public static void UseDevelopmentMiddlewares(WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        public static void UseMiddlewares(WebApplication app)
        {
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });
        }

        public static void AddTransientDependencies(WebApplicationBuilder builder)
        {
            // services
            builder.Services.AddSingleton<IJwtService, JwtService>();
            builder.Services.AddTransient<IAuthService, AuthService>();

            // repository
        }

        public static void AddAuthorization(WebApplicationBuilder builder)
        {
            string issuer = builder.Configuration[AppSettingsKeys.JWT_ISSUER_KEY];
            string audience = builder.Configuration[AppSettingsKeys.JWT_AUDIENCE_KEY];
            string secretKey = builder.Configuration[AppSettingsKeys.JWT_SECRET_KEY];

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = issuer,
                        ValidAudience = audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                    };
                });
        }

        public static void AddDbContext(WebApplicationBuilder builder)
        {
            string dbConnectionString = builder.Configuration[AppSettingsKeys.DB_CONNECTION_STRING];

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(dbConnectionString);
            });
        }
    }
}
