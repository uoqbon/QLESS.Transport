using QLESS.Transport.Contracts.DTO;
using System.Threading.Tasks;

namespace QLESS.Transport.Business.Contracts.Services
{
    public interface ICommuteHistoryService
    {
        Task AddAsync(long cardId, int stationId, bool isDeparture);
        Task<CommuteHistoryDTO> GetLatestEntryAsync(long cardId);
    }
}
