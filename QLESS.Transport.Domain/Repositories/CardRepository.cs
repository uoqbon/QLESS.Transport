using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QLESS.Transport.Core.DTO;
using QLESS.Transport.Data.Contracts;
using QLESS.Transport.Data.Contracts.Repositories;
using QLESS.Transport.Data.Entities;
using System.Threading.Tasks;

namespace QLESS.Transport.Data.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly IQLESSTransportContext _dbContext;
        private readonly IMapper _mapper;

        public CardRepository(IQLESSTransportContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }        

        public async Task<long> CreateAsync(CardDTO dto)
        {
            var newCard = _mapper.Map<Card>(dto);    
            await _dbContext.Card.AddAsync(newCard);
            await _dbContext.SaveChangesAsync();

            return newCard.Id;
        }

        public async Task<CardDTO> GetByIdAsync(long id)
        {
            var data = await _dbContext.Card.Include(c => c.CardType).FirstOrDefaultAsync(r => r.Id == id);
            return _mapper.Map<CardDTO>(data);
        }

        public async Task UpdateLoadBalanceAsync(long cardId, decimal balance)
        {
            var data = await _dbContext.Card.FirstOrDefaultAsync(c => c.Id == cardId);

            if (data != null)
            {
                data.Load = balance;
                _dbContext.Update(data);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
