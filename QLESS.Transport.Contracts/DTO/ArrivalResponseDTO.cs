namespace QLESS.Transport.Contracts.DTO
{
    public class ArrivalResponseDTO
    {
        public decimal LoadBalance { get; set; }
        public decimal Fare { get; set; }
        public bool IsExitAllowed { get; set; }        
    }
}
