using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLESS.Transport.Domain.Entities
{
    public class CommuteHistory
    {
        public long Id { get; set; }
        public long CardId { get; set; }
        public int StationId { get; set; }
        public bool IsDeparture { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("CardId")]
        [InverseProperty("CommuteHistory")]
        public Card Card { get; set; }

        [ForeignKey("StationId")]
        [InverseProperty("CommuteHistory")]
        public Station Station { get; set; }
    }
}
