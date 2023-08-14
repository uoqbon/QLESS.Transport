using Microsoft.AspNetCore.Mvc;
using QLESS.Transport.Business.Contracts.Managers;
using QLESS.Transport.Business.Contracts.Services;
using QLESS.Transport.Core.DTO;
using System.Threading.Tasks;

namespace QLESS.Transport.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommuteController : ControllerBase
    {
        private readonly ICommuteManager _commuteManager;
        private readonly ICommuteHistoryService _commuteHistoryService;

        public CommuteController(ICommuteManager commuteManager, ICommuteHistoryService commuteHistoryService)
        {
            _commuteManager = commuteManager;
            _commuteHistoryService = commuteHistoryService;
        }

        /// <summary>
        /// Use Transport Card to enter a train station
        /// </summary>
        /// <param name="cardId">Card Id</param>
        /// <param name="stationId">Train Station Id</param>
        /// <returns>Departure Information</returns>
        [HttpPost("Depart/{cardId}/{stationId}")]
        public Task<DepartureResponseDTO> Depart(long cardId, int stationId)
        {
            return _commuteManager.DepartAsync(cardId, stationId);
        }

        /// <summary>
        /// Use Transport Card to exit a train station
        /// </summary>
        /// <param name="cardId">Card Id</param>
        /// <param name="stationId">Train Station Id</param>
        /// <returns>Arrival Information</returns>
        [HttpPost("Arrive/{cardId}/{stationId}")]
        public Task<ArrivalResponseDTO> Arrive(long cardId, int stationId)
        {
            return _commuteManager.ArriveAsync(cardId, stationId);
        }

        /// <summary>
        /// Gets last commute information from Transport Card
        /// </summary>
        /// <param name="cardId">Card Id</param>
        /// <returns>Commute History Information</returns>
        [HttpGet("GetLastHistoryEntry/{cardId}")]
        public Task<CommuteHistoryDTO> GetLastHistoryEntry(long cardId)
        {
            return _commuteHistoryService.GetLatestEntryAsync(cardId);
        }
    }
}
