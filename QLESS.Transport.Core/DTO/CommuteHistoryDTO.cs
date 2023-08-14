using System;

namespace QLESS.Transport.Core.DTO
{
    public class CommuteHistoryDTO
    {
        public long Id { get; set; }
        public long CardId { get; set; }
        public int StationId { get; set; }
        public bool IsDeparture { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
