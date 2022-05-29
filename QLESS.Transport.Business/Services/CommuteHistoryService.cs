using QLESS.Transport.Business.Contracts.Services;
using QLESS.Transport.Contracts.DTO;
using QLESS.Transport.Domain.Contracts.Repositories;
using System.Threading.Tasks;

namespace QLESS.Transport.Business.Services
{
    public class CommuteHistoryService : ICommuteHistoryService
    {
        private readonly ICommuteHistoryRepository _commuteHistoryRepository;

        public CommuteHistoryService(ICommuteHistoryRepository commuteHistoryRepository)
        {   
            _commuteHistoryRepository = commuteHistoryRepository;
        }

        public Task AddAsync(long cardId, int stationId, bool isDeparture)
        {
            return _commuteHistoryRepository.AddAsync(cardId, stationId, isDeparture);
        }

        public Task<CommuteHistoryDTO> GetLatestEntryAsync(long cardId)
        {
            return _commuteHistoryRepository.GetLatestEntryAsync(cardId);
        }
    }
}
