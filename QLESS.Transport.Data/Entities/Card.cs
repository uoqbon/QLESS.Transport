using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLESS.Transport.Data.Entities
{
    public class Card
    {
        public long Id { get; set; }
        public decimal Load { get; set; }
        public string DiscountReferenceId { get; set; }
        public short CardTypeId { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("CardTypeId")]
        [InverseProperty("Card")]
        public CardType CardType { get; set; }

        [InverseProperty("Card")]
        public List<CommuteHistory> CommuteHistory { get; set; }
    }
}
