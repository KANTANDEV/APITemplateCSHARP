using Microsoft.Extensions.DependencyInjection;

namespace MiniApiTemplate.Config
{
    public static class CorsConfig
    {
        public static IServiceCollection ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()  // Autorise toutes les origines (⚠️ à restreindre en prod)
                          .AllowAnyMethod()  // Autorise toutes les méthodes HTTP (GET, POST, PUT, DELETE)
                          .AllowAnyHeader(); // Autorise tous les en-têtes HTTP
                });
            });

            return services;
        }
    }
}