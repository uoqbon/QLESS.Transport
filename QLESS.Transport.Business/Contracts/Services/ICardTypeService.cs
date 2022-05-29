using QLESS.Transport.Contracts.Constants;
using QLESS.Transport.Contracts.DTO;
using System.Threading.Tasks;

namespace QLESS.Transport.Business.Contracts.Services
{
    public interface ICardTypeService
    {
        Task<CardTypeDTO> GetByIdAsync(CardTypes cardType);
    }
}
