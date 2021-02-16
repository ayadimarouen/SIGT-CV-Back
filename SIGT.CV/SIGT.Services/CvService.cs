using SIGT.DTO;
using SIGT.Entities;
using SIGT.Infrastructure.IRepositories;
using SIGT.Infrastructure.IServices;
using System.Threading.Tasks;

namespace SIGT.Services
{
    public class CvService : ICvService<CvDTO>
    {
        private readonly ICvRepository<Cv> _cvRepository;

        public CvService(ICvRepository<Cv> cvRepository)
        {
            _cvRepository = cvRepository;
        }

        public async Task<CvDTO> ReadCV()
        {
            return await _cvRepository.ReadCV();
            
        }
    }
}
