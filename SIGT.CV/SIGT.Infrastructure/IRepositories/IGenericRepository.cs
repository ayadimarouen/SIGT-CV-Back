using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SIGT.Infrastructure.IRepositories
{
    public interface IGenericRepository
    {
        Task SetDbContext(DbContext dbContext);
    }
}