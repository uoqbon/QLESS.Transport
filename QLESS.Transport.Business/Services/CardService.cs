using QLESS.Transport.Business.Contracts.Services;
using QLESS.Transport.Core.DTO;
using QLESS.Transport.Data.Contracts.Repositories;
using System.Threading.Tasks;

namespace QLESS.Transport.Business.Services
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;

        public CardService(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }        

        public Task<CardDTO> GetByIdAsync(long id)
        {
            return _cardRepository.GetByIdAsync(id);
        }

        public Task<long> CreateAsync(CardDTO newCard)
        {
            return _cardRepository.CreateAsync(newCard);
        }

        public Task UpdateLoadBalanceAsync(long cardId, decimal balance)
        {
            return _cardRepository.UpdateLoadBalanceAsync(cardId, balance);
        }
    }
}
