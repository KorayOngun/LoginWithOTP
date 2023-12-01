using OrganikHaberlesme.Application.Interfaces.Repositories;
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
    public class UserWriteRepository : WriteRepositories<User>,IUserWriteRepository 
    {
        public UserWriteRepository(AppDbContext context) : base(context)
        {
           
        }
    }
}
