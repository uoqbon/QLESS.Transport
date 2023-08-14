using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using QLESS.Transport.Data.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace QLESS.Transport.Data.Contracts
{
    public interface IQLESSTransportContext
    {
        DbSet<Card> Card { get; set; }
        DbSet<CardType> CardType { get; set; }
        DbSet<CommuteHistory> CommuteHistory { get; set; }
        DbSet<Station> Station { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        EntityEntry Update(object entity);
    }
}
