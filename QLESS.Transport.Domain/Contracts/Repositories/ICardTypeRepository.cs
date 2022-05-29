using QLESS.Transport.Contracts.Constants;
using QLESS.Transport.Contracts.DTO;
using System.Threading.Tasks;

namespace QLESS.Transport.Domain.Contracts.Repositories
{
    public interface ICardTypeRepository
    {
        Task<CardTypeDTO> GetByIdAsync(CardTypes cardType);
    }
}
