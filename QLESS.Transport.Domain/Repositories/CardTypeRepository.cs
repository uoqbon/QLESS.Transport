using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QLESS.Transport.Core.Constants;
using QLESS.Transport.Core.DTO;
using QLESS.Transport.Data.Contracts;
using QLESS.Transport.Data.Contracts.Repositories;
using System.Threading.Tasks;

namespace QLESS.Transport.Data.Repositories
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
