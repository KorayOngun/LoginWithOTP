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
        protected readonly AppDbContext _context;

        public WriteRepositories(AppDbContext context)
        {
            _context = context;
        }

        public bool Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return _context.SaveChanges() > 0;
        }

        public async Task<bool> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            return (await  _context.SaveChangesAsync()) > 0;
        }

        public bool Update(T entity)
        {
            _context.Update(entity);
            return _context.SaveChanges()> 0;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            await Task.Run(() => _context.Update(entity));
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
