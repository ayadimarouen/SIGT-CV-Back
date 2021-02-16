using Microsoft.EntityFrameworkCore;
using SIGT.Infrastructure.IRepositories;
using System;
using System.Threading.Tasks;

namespace SIGT.EFCore.Repositories
{
    public abstract class GenericRepository<TContext> : IGenericRepository
        where TContext : DbContext, IDisposable
    {
        protected TContext dbContext;
        public async Task SetDbContext(DbContext dContext)
        {
            if (dContext != null)
            {
                this.Dispose(true);
                this.dbContext = (TContext)dContext;
            }
        }  

        ~GenericRepository()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); // so that Dispose(false) isn't called later
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (dbContext != null)
                {
                    dbContext.Dispose();
                }
            }
        }
        protected GenericRepository(TContext context)
        {
            this.dbContext = context;
        }
        protected TContext GetContext()
        {
            return dbContext;
        }

    }

}
