using OrganikHaberlesme.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganikHaberlesme.Application.Interfaces.Repositories.UserRepo
{
    public interface IUserReadRepository : IReadRepository<User>
    {
        Task<User> GetByUserName(string userName);
    }
}
