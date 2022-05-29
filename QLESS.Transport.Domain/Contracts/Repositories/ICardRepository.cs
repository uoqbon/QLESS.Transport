using QLESS.Transport.Contracts.DTO;
using System.Threading.Tasks;

namespace QLESS.Transport.Domain.Contracts.Repositories
{
    public interface ICardRepository
    {
        Task<long> CreateAsync(CardDTO newCard);
        Task<CardDTO> GetByIdAsync(long id);
        Task UpdateLoadBalanceAsync(long cardId, decimal balance);
    }
}
