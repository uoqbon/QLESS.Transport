using QLESS.Transport.Core.DTO;
using System.Threading.Tasks;

namespace QLESS.Transport.Data.Contracts.Repositories
{
    public interface ICommuteHistoryRepository
    {
        Task AddAsync(long cardId, int stationId, bool isDeparture);
        Task<CommuteHistoryDTO> GetLatestEntryAsync(long cardId);    }
}
