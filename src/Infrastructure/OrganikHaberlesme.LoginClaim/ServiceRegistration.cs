using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrganikHaberlesme.Application.Interfaces.LoginClaim;
using OrganikHaberlesme.Application.Interfaces.Repositories.LoginClaimRepo;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganikHaberlesme.LoginClaim
{
    public static class ServiceRegistration
    {
        public static void AddLoginClaim(this IServiceCollection services,IConfiguration configuration)
        {
          
            services.AddScoped<ILoginClaimRepo, LoginClaimRepository>(opt =>
            {
                var redisConfiguration = new ConfigurationOptions
                {
                    EndPoints = { configuration.GetConnectionString("LoginClaim") },
                    Password = configuration["LoginClaimPassword"]
                };
                return new LoginClaimRepository(redisConfiguration);
            });
            services.AddScoped<ILoginClaimServices,LoginClaimService>();
        }
    }
}
