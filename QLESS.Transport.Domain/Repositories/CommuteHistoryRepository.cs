using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QLESS.Transport.Contracts.DTO;
using QLESS.Transport.Domain.Contracts;
using QLESS.Transport.Domain.Contracts.Repositories;
using QLESS.Transport.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace QLESS.Transport.Domain.Repositories
{
    public class CommuteHistoryRepository : ICommuteHistoryRepository
    {
        private readonly IQLESSTransportContext _dbContext;
        private readonly IMapper _mapper;

        public CommuteHistoryRepository(IQLESSTransportContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task AddAsync(long cardId, int stationId, bool isDeparture)
        {
            var newEntry = new CommuteHistory
            {
                CardId = cardId,
                StationId = stationId,
                IsDeparture = isDeparture,
                CreatedDate = DateTime.UtcNow
            };

            await _dbContext.CommuteHistory.AddAsync(newEntry);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<CommuteHistoryDTO> GetLatestEntryAsync(long cardId)
        {
            var data = await _dbContext.CommuteHistory
                .Where(h => h.CardId == cardId)
                .OrderByDescending(h => h.CreatedDate)
                .FirstOrDefaultAsync();

            return _mapper.Map<CommuteHistoryDTO>(data);
        }
    }
}
