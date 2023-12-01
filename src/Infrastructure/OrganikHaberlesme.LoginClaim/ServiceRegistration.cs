using Microsoft.Extensions.DependencyInjection;
using OrganikHaberlesme.Application.Interfaces.LoginClaim;
using OrganikHaberlesme.Application.Interfaces.Repositories.LoginClaimRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganikHaberlesme.LoginClaim
{
    public static class ServiceRegistration
    {
        public static void AddLoginClaim(this IServiceCollection services,string _dbPath)
        {
          
            services.AddScoped<ILoginClaimRepo, LoginClaimRepository>();
            services.AddScoped<ILoginClaimServices,LoginClaimService>();

        }
    }
}
