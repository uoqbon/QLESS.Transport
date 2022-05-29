using QLESS.Transport.Business.Contracts.Managers;
using QLESS.Transport.Business.Contracts.Services;
using QLESS.Transport.Contracts.Constants;
using QLESS.Transport.Contracts.DTO;
using System;
using System.Threading.Tasks;

namespace QLESS.Transport.Business.Managers
{
    public class CardTransactionManager : ICardTransactionManager
    {
        private readonly ICardService _cardService;
        private readonly ICardTypeService _cardTypeService;

        public CardTransactionManager(ICardService cardService, ICardTypeService cardTypeService)
        {
            _cardService = cardService;
            _cardTypeService = cardTypeService;           
        }

        public async Task<long> CreateNewCardAsync(CardTypes cardType, string discountReferenceId)
        {
            var cardTypeInfo = await _cardTypeService.GetByIdAsync(cardType);

            var newCard = new CardDTO
            {
                CardTypeId = cardType,
                DiscountReferenceId = discountReferenceId,
                Load = cardTypeInfo.InitialLoad,
                CreatedDate = DateTime.UtcNow,
            };             

            return await _cardService.CreateAsync(newCard);
        }
    }
}
