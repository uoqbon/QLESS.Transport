using Microsoft.AspNetCore.Mvc;
using QLESS.Transport.Business.Contracts.Managers;
using QLESS.Transport.Business.Contracts.Services;
using QLESS.Transport.Contracts.DTO;
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

        [HttpPost("Depart/{cardId}/{stationId}")]
        public Task<DepartureResponseDTO> Depart(long cardId, int stationId)
        {
            return _commuteManager.DepartAsync(cardId, stationId);
        }

        [HttpPost("Arrive/{cardId}/{stationId}")]
        public Task<ArrivalResponseDTO> Arrive(long cardId, int stationId)
        {
            return _commuteManager.ArriveAsync(cardId, stationId);
        }

        [HttpGet("GetLastHistoryEntry/{cardId}")]
        public Task<CommuteHistoryDTO> GetLastHistoryEntry(long cardId)
        {
            return _commuteHistoryService.GetLatestEntryAsync(cardId);
        }
    }
}
