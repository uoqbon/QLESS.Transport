using QLESS.Transport.Contracts.DTO;
using System.Threading.Tasks;

namespace QLESS.Transport.Business.Contracts.Services
{
    public interface ICardService
    {
        Task<CardDTO> GetByIdAsync(long id);
        Task<long> CreateAsync(CardDTO newCard);
        Task UpdateLoadBalanceAsync(long cardId, decimal balance);
    }
}
