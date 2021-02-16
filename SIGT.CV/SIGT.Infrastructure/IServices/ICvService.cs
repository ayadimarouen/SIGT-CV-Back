using SIGT.DTO;
using System.Threading.Tasks;

namespace SIGT.Infrastructure.IServices
{
    public interface ICvService<TEntityDTO> where TEntityDTO : CvDTO
    {
        public Task<CvDTO> ReadCV();
    }
}
