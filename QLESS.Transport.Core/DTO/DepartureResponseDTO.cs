namespace QLESS.Transport.Core.DTO
{
    public class DepartureResponseDTO
    {
        public decimal LoadBalance { get; set; }
        public bool IsEntryAllowed { get; set; }
        public bool IsExpired { get; set; }
    }
}
