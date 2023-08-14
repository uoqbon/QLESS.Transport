using QLESS.Transport.Core.Constants;
using System.Threading.Tasks;

namespace QLESS.Transport.Business.Contracts.Managers
{
    public interface ICardTransactionManager
    {
        bool ValidateDiscountReferenceId(string discountReferenceId);
        Task<long> CreateNewCardAsync(CardTypes cardType, string discountReferenceId);
    }
}
