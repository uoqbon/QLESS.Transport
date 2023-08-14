using System.ComponentModel.DataAnnotations.Schema;

namespace QLESS.Transport.Data.Entities
{
    public class Station
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public short Distance { get; set; }

        [InverseProperty("Station")]
        public CommuteHistory CommuteHistory { get; set; }
    }
}
