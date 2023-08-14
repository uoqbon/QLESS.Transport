using QLESS.Transport.Core.DTO;
using System.Threading.Tasks;

namespace QLESS.Transport.Business.Contracts.Managers
{
    public interface ICommuteManager
    {
        Task<DepartureResponseDTO> DepartAsync(long cardId, int stationId);
        Task<ArrivalResponseDTO> ArriveAsync(long cardId, int stationId);
    }
}
