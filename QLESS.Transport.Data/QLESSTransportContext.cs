using Microsoft.EntityFrameworkCore;
using QLESS.Transport.Data.Contracts;
using QLESS.Transport.Data.Entities;

namespace QLESS.Transport.Data
{
    public class QLESSTransportContext : DbContext, IQLESSTransportContext
    {
        private string _schemaName;        

        public QLESSTransportContext(DbContextOptions<QLESSTransportContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;            
        }       

        public virtual DbSet<Card> Card { get; set; }        
        public virtual DbSet<CardType> CardType { get; set; }        
        public virtual DbSet<CommuteHistory> CommuteHistory { get; set; }
        public virtual DbSet<Station> Station { get; set; }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (string.IsNullOrEmpty(_schemaName))
            {
                _schemaName = "QLESS";
            }
            modelBuilder.HasDefaultSchema(_schemaName);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Card>()
                .HasOne(c => c.CardType)
                .WithOne(c => c.Card);         

            modelBuilder.Entity<CommuteHistory>()
                .HasOne(h => h.Card)
                .WithMany(c => c.CommuteHistory);
        }
    }
}
