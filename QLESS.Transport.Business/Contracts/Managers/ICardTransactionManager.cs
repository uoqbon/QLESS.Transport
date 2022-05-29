using QLESS.Transport.Contracts.Constants;
using System.Threading.Tasks;

namespace QLESS.Transport.Business.Contracts.Managers
{
    public interface ICardTransactionManager
    {
        Task<long> CreateNewCardAsync(CardTypes cardType, string discountReferenceId);
    }
}
