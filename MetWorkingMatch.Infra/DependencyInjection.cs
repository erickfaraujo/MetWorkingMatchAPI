using MetWorkingMatch.Application.Interfaces;
using MetWorkingMatch.Infra.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MetWorkingMatch.Infra
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseMySql(configuration.GetConnectionString("DefaultConnection"),
                                     b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
                           .EnableSensitiveDataLogging());

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

        }
    }
}
