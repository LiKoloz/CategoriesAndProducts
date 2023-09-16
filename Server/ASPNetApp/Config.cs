using DataBaseWorker;
using Microsoft.Extensions.DependencyInjection;

namespace ASPNetApp
{

    public static class Config
    {
        public static void AddAppContext(this IServiceCollection services) {
            services.AddDbContext<ApplicationContext>()
                .AddScoped<ApplicationDb>();
        }
    }
}
