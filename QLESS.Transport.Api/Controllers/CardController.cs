using Microsoft.AspNetCore.Mvc;
using QLESS.Transport.Business.Contracts.Managers;
using QLESS.Transport.Business.Contracts.Services;
using QLESS.Transport.Contracts.Constants;
using QLESS.Transport.Contracts.DTO;
using System;
using System.Threading.Tasks;

namespace QLESS.Transport.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardController : ControllerBase
    {
        private readonly ICardTransactionManager _cardTransactionManager;
        private readonly ICardService _cardService;

        public CardController(ICardTransactionManager cardTransactionManager, ICardService cardService)
        {
            _cardTransactionManager = cardTransactionManager;
            _cardService = cardService;
        }

        /// <summary>
        /// Creates a new Transport Card
        /// </summary>
        /// <returns>Card Id</returns>
        [HttpPost]
        public Task<long> Create()
        {
            return CreateAsync(CardTypes.Regular, null);
        }

        /// <summary>
        /// Creates a new Discounted Transport Card
        /// </summary>
        /// <param name="discountReferenceId">Discount Reference Id Number</param>
        /// <returns>Card Id</returns>
        /// <exception cref="ArgumentException"></exception>
        [HttpPost("CreateDiscounted/{discountReferenceId}")]
        public Task<long> Create(string discountReferenceId)
        {
            if (!_cardTransactionManager.ValidateDiscountReferenceId(discountReferenceId))
                throw new ArgumentException("Invalid Discount Reference Id");

            return CreateAsync(CardTypes.Discounted, discountReferenceId);
        }        

        /// <summary>
        /// Gets Transport Card Information
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Transport Card</returns>
        [HttpGet("{id}")]
        public Task<CardDTO> Get(long id)
        {
            return _cardService.GetByIdAsync(id);
        }

        private Task<long> CreateAsync(CardTypes cardType, string discountReferenceId)
        {
            return _cardTransactionManager.CreateNewCardAsync(cardType, discountReferenceId);
        }
    }
}
