using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SIGT.Infrastructure.IRepositories
{
    public interface IGenericBaseRepository<TType> : IGenericRepository
        where TType : class
    {
        Task<List<TType>> GenericGet(
                Expression<Func<TType, bool>> filter = null,
                Func<IQueryable<TType>, IOrderedQueryable<TType>> orderBy = null,
                string includeProperties = "", DbContext dbContext = null);
        Task<TType> GenericGetFirstOrDefaultAsync(
                  Expression<Func<TType, bool>> filter = null,
                  Func<IQueryable<TType>, IOrderedQueryable<TType>> orderBy = null,
                  string includeProperties = "", DbContext dbContext = null);

        Task<TType> GetById(object id, DbContext dbContext = null);
       



    }
}