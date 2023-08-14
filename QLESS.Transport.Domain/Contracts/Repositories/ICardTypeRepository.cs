using QLESS.Transport.Core.Constants;
using QLESS.Transport.Core.DTO;
using System.Threading.Tasks;

namespace QLESS.Transport.Data.Contracts.Repositories
{
    public interface ICardTypeRepository
    {
        Task<CardTypeDTO> GetByIdAsync(CardTypes cardType);
    }
}
