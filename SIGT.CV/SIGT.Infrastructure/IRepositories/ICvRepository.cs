using SIGT.DTO;
using SIGT.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGT.Infrastructure.IRepositories
{
    public interface ICvRepository<TEntity> : IGenericBaseRepository<Cv> where TEntity : Cv
    {
        Task<CvDTO> ReadCV();
        Task<List<ExperienceDTO>> buildExperience(int cvId);
    }
}
