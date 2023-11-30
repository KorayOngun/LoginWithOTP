using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganikHaberlesme.Application.Interfaces.Repositories
{
    public interface IWriteRepository<T> where T : class
    {
        Task<bool> AddAsync(T entity);
        Task<bool> Update(T entity);
    }
}
