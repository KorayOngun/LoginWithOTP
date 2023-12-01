using OrganikHaberlesme.Application.Interfaces.Repositories.UserRepo;
using OrganikHaberlesme.Domain.Entities;
using OrganikHaberlesme.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganikHaberlesme.Persistence.Repositories.UserRepositories
{
    public class UserReadRepository : ReadRepository<User>,IUserReadRepository
    {
        public UserReadRepository(AppDbContext context) : base(context) 
        {

        }
      
    }
}
