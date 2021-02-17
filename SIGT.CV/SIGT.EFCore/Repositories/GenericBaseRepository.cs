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

        public async Task<TType> GetById(object id, DbContext dContext = null)
        {

            await SetDbContext(dContext);
            return await dbContext.Set<TType>().FindAsync(id);
        }


    }

}
