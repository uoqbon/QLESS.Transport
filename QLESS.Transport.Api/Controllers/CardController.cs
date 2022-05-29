using Microsoft.AspNetCore.Mvc;
using QLESS.Transport.Business.Contracts.Managers;
using QLESS.Transport.Business.Contracts.Services;
using QLESS.Transport.Contracts.Constants;
using QLESS.Transport.Contracts.DTO;
using System;
using System.Text.RegularExpressions;
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

        [HttpPost]
        public Task<long> Create()
        {
            return CreateAsync(CardTypes.Regular, null);
        }

        [HttpPost("CreateDiscounted/{discountReferenceId}")]
        public Task<long> Create(string discountReferenceId)
        {
            var regex = @"^(?=(.{14}|.{12})$)[a-zA-Z0-9]+(?:-[a-zA-Z0-9]+){2}$";
            var match = Regex.Match(discountReferenceId, regex, RegexOptions.IgnoreCase);

            if (!match.Success)
                throw new ArgumentException("Invalid Discount Reference Id");

            return CreateAsync(CardTypes.Discounted, discountReferenceId);
        }        

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
