using Microsoft.EntityFrameworkCore;
using SIGT.Infrastructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SIGT.EFCore.Repositories
{

    public abstract class GenericBaseRepository<TType, TContext> : GenericRepository<TContext>, IGenericBaseRepository<TType> where TType : class
        where TContext : DbContext, IDisposable
    {

        protected GenericBaseRepository(TContext context) : base(context)
        {
            this.dbContext = context;
        }



        public virtual async Task<List<TType>> GenericGet(
    Expression<Func<TType, bool>> filter = null,
    Func<IQueryable<TType>, IOrderedQueryable<TType>> orderBy = null,
    string includeProperties = "", DbContext dContext = null)
        {
            if (dContext != null)
                await SetDbContext(dContext);
            IQueryable<TType> query = this.dbContext.Set<TType>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }


            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        



        public async Task<TType> GetById(object id, DbContext dContext = null)
        {

            await SetDbContext(dContext);
            return await dbContext.Set<TType>().FindAsync(id);
        }





        public virtual async Task<TType> GenericGetFirstOrDefaultAsync(Expression<Func<TType, bool>> filter = null, Func<IQueryable<TType>, IOrderedQueryable<TType>> orderBy = null, string includeProperties = "", DbContext dContext = null)
        {

            await SetDbContext(dContext);
            IQueryable<TType> query = this.dbContext.Set<TType>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }


            if (orderBy != null)
            {
                return await orderBy(query).FirstOrDefaultAsync();
            }
            else
            {
                return await query.FirstOrDefaultAsync();
            }
        }


    }

}
