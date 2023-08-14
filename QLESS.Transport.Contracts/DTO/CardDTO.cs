using QLESS.Transport.Core.Constants;
using System;

namespace QLESS.Transport.Core.DTO
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
