using QLESS.Transport.Core.DTO;
using System.Threading.Tasks;

namespace QLESS.Transport.Data.Contracts.Repositories
{
    public interface ICardRepository
    {
        Task<long> CreateAsync(CardDTO newCard);
        Task<CardDTO> GetByIdAsync(long id);
        Task UpdateLoadBalanceAsync(long cardId, decimal balance);
    }
}
