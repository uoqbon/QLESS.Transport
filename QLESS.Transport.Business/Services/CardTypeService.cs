using QLESS.Transport.Business.Contracts.Services;
using QLESS.Transport.Contracts.Constants;
using QLESS.Transport.Contracts.DTO;
using QLESS.Transport.Domain.Contracts.Repositories;
using System.Threading.Tasks;

namespace QLESS.Transport.Business.Services
{
    public class CardTypeService : ICardTypeService
    {
        private readonly ICardTypeRepository _cardTypeRepository;

        public CardTypeService(ICardTypeRepository cardTypeRepository)
        {
            _cardTypeRepository = cardTypeRepository;
        }

        public Task<CardTypeDTO> GetByIdAsync(CardTypes cardType)
        {
            return _cardTypeRepository.GetByIdAsync(cardType);
        }
    }
}
