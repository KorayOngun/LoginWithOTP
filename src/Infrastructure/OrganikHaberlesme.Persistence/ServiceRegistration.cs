using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OrganikHaberlesme.Application.Interfaces.Repositories.UserRepo;
using OrganikHaberlesme.Domain.Entities;
using OrganikHaberlesme.Persistence.Context;
using OrganikHaberlesme.Persistence.Repositories.UserRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganikHaberlesme.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistence(this IServiceCollection service,string dbPath)
        {
            
            service.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(dbPath));

            service.AddScoped<IUserReadRepository, UserReadRepository>();
            service.AddScoped<IUserWriteRepository, UserWriteRepository>();

        }
        public static void DbSeed(this IServiceProvider service)
        {
            using(var scope = service.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                context.Database.EnsureCreated();
                if (!context.Users.Any())
                {
                    context.Users.AddRange(new User[]
                    {
                    new(){Id = Guid.NewGuid(),CreatedDate = DateTime.Now,Email="koray@mail",Name="koray",Password="123",PhoneNumber="+9050505050505",TwoFactor=true },
                    new(){Id = Guid.NewGuid(),CreatedDate = DateTime.Now,Email="ali@mail",Name="ali",Password="321",PhoneNumber="+90303030303003",TwoFactor=true},
                    new(){Id = Guid.NewGuid(),CreatedDate = DateTime.Now,Email="veli@mail",Name="veli",Password="132",PhoneNumber="+902020202020202",TwoFactor=true},
                    new(){Id = Guid.NewGuid(),CreatedDate = DateTime.Now,Email="koraygg28@gmail.com",Name="k",Password="1",PhoneNumber="+654654",TwoFactor=true},
                    });
                }
                context.SaveChanges();
            }
             
        }
    }
}
