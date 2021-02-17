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
        Task<TType> GetById(object id, DbContext dbContext = null);
    }
}