using QLESS.Transport.Core.Constants;
using QLESS.Transport.Core.DTO;
using System.Threading.Tasks;

namespace QLESS.Transport.Business.Contracts.Services
{
    public interface ICardTypeService
    {
        Task<CardTypeDTO> GetByIdAsync(CardTypes cardType);
    }
}
