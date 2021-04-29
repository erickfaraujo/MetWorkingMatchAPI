using System;
using MediatR;
using MetWorkingMatch.Application.Contracts;
using MetWorkingMatch.Application.Interfaces;
using MetWorkingMatch.Application.Pedido.Commands;
using MetWorkingMatch.Application.Pedido.Handlers;
using MetWorkingMatch.Domain.Interfaces;
using MetWorkingMatch.Infra.Persistence;
using MetWorkingMatch.Infra.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;

namespace MetWorkingMatch.Infra
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseMySql(configuration["ConnectionString"],
                        b =>
                        {
                            b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                            b.EnableRetryOnFailure();
                        }), ServiceLifetime.Transient);

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IGeoService, GeoService>();
            
            services.AddHttpClient<IUserService, UserService>(client =>
                {
                    client.BaseAddress = new Uri(configuration["userServiceBaseURL"]);
                })
                .SetHandlerLifetime(TimeSpan.FromMinutes(5))
                .AddPolicyHandler(message => HttpPolicyExtensions.HandleTransientHttpError()
                    .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                    .WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))));
            
            services.AddHttpClient<IGeoService, GeoService>(client =>
                {
                    client.BaseAddress = new Uri(configuration["geoServiceBaseURL"]);
                })
                .SetHandlerLifetime(TimeSpan.FromMinutes(5))
                .AddPolicyHandler(message => HttpPolicyExtensions.HandleTransientHttpError()
                    .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                    .WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))));

        }
    }
}
