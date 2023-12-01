using Microsoft.EntityFrameworkCore.Query;
using OrganikHaberlesme.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrganikHaberlesme.Application.Interfaces.Repositories
{
    public interface IReadRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(Guid id,bool enableTracking = false);
        Task<IList<T>> GetAllAsync(bool enableTracking = false);
        Task<IList<T>> GetAllWithFilterAsync(Expression<Func<T,bool>> filter,bool? enableTracking = false);
        Task<bool> IsExistAsync(Expression<Func<T,bool>> predicate);
    }
}


