using OrganikHaberlesme.Application.Interfaces.Repositories;
using OrganikHaberlesme.Domain;
using OrganikHaberlesme.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganikHaberlesme.Persistence.Repositories
{
    public class WriteRepositories<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;

        public WriteRepositories(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<bool> Update(T entity)
        {
             _context.Set<T>().Update(entity);
             return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
