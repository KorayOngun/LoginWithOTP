using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using OrganikHaberlesme.Application.Interfaces.Repositories;
using OrganikHaberlesme.Domain;
using OrganikHaberlesme.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrganikHaberlesme.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext _context;

        public ReadRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IList<T>> GetAllAsync(bool enableTracking = false)
        {
            IQueryable<T> queryable = _context.Set<T>();
            if (enableTracking == false) queryable = queryable.AsNoTracking();
            return await queryable.ToListAsync();
        }

        public async Task<IList<T>> GetAllWithFilterAsync(Expression<Func<T, bool>> filter, bool? enableTracking = false)
        {
            IQueryable<T> queryable = _context.Set<T>();
            if (enableTracking == false) queryable = queryable.AsNoTracking();
            return await queryable.Where(filter).ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id, bool enableTracking = false)
        {
            IQueryable<T> queryable = _context.Set<T>();
            if (enableTracking == false) queryable = queryable.AsNoTracking();
            return await queryable.FirstOrDefaultAsync(b=>b.Id == id);
        }

        public async Task<bool> IsExistAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).AnyAsync();
        }
    }
}
