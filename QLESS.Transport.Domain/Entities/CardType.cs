using System.ComponentModel.DataAnnotations.Schema;

namespace QLESS.Transport.Domain.Entities
{
    public class CardType
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public decimal Rate { get; set; }
        public decimal InitialLoad { get; set; }
                
        [InverseProperty("CardType")]
        public Card Card { get; set; }
    }
}
