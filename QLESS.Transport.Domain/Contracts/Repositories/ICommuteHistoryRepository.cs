using QLESS.Transport.Contracts.DTO;
using System.Threading.Tasks;

namespace QLESS.Transport.Domain.Contracts.Repositories
{
    public interface ICommuteHistoryRepository
    {
        Task AddAsync(long cardId, int stationId, bool isDeparture);
        Task<CommuteHistoryDTO> GetLatestEntryAsync(long cardId);    }
}
