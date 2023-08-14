using QLESS.Transport.Business.Contracts.Managers;
using QLESS.Transport.Business.Contracts.Services;
using QLESS.Transport.Core.DTO;
using System;
using System.Threading.Tasks;

namespace QLESS.Transport.Business.Managers
{
    public class CommuteManager : ICommuteManager
    {
        private readonly ICardService _cardService;
        private readonly ICommuteHistoryService _commuteHistoryService;

        public CommuteManager(ICommuteHistoryService commuteHistoryService, ICardService cardService)
        {
            _commuteHistoryService = commuteHistoryService;
            _cardService = cardService;                
        }

        public async Task<DepartureResponseDTO> DepartAsync(long cardId, int stationId)
        {
            var cardInfo = await _cardService.GetByIdAsync(cardId);            

            var response = new DepartureResponseDTO
            {
                LoadBalance = cardInfo.Load,
                IsExpired = cardInfo.CreatedDate.AddYears(5) < DateTime.UtcNow
            };

            if (response.IsExpired)
            {
                response.IsEntryAllowed = false;
                return response;
            }

            var latestHistory = await _commuteHistoryService.GetLatestEntryAsync(cardId);

            var balance = cardInfo.Load - cardInfo.CardType.Rate;

            if (balance < 0 || (latestHistory != null && latestHistory.IsDeparture))
            {
                response.IsEntryAllowed = false;
            }
            else
            {
                response.IsEntryAllowed = true;
                await _commuteHistoryService.AddAsync(cardId, stationId, true);
            }

            return response;
        }

        public async Task<ArrivalResponseDTO> ArriveAsync(long cardId, int stationId)
        {
            var cardInfo = await _cardService.GetByIdAsync(cardId);     
            
            var response = new ArrivalResponseDTO
            {
                Fare = cardInfo.CardType.Rate                
            };          

            var balance = cardInfo.Load - cardInfo.CardType.Rate;

            var latestHistory = await _commuteHistoryService.GetLatestEntryAsync(cardId);

            if (balance < 0 || !latestHistory.IsDeparture)
            {
                response.LoadBalance = cardInfo.Load;
                response.IsExitAllowed = false;
            }
            else
            {                
                response.LoadBalance = balance;
                response.IsExitAllowed = true;

                await _cardService.UpdateLoadBalanceAsync(cardId, balance);
                await _commuteHistoryService.AddAsync(cardId, stationId, false);              
            }

            return response;
        }
    }
}
