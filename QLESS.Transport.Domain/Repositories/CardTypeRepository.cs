using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QLESS.Transport.Contracts.Constants;
using QLESS.Transport.Contracts.DTO;
using QLESS.Transport.Domain.Contracts;
using QLESS.Transport.Domain.Contracts.Repositories;
using System.Threading.Tasks;

namespace QLESS.Transport.Domain.Repositories
{
    public class CardTypeRepository : ICardTypeRepository
    {
        private readonly IQLESSTransportContext _dbContext;
        private readonly IMapper _mapper;

        public CardTypeRepository(IQLESSTransportContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CardTypeDTO> GetByIdAsync(CardTypes cardType)
        {
            var data = await _dbContext.CardType.FirstOrDefaultAsync(r => r.Id == (short)cardType);
            return _mapper.Map<CardTypeDTO>(data);
        }
    }
}
