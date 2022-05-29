using QLESS.Transport.Contracts.Constants;
using System;

namespace QLESS.Transport.Contracts.DTO
{
    public class CardDTO
    {
        public long Id { get; set; }
        public decimal Load { get; set; }
        public string DiscountReferenceId { get; set; }
        public CardTypes CardTypeId { get; set; }
        public DateTime CreatedDate { get; set; }

        public CardTypeDTO CardType { get; set; }
    }
}
