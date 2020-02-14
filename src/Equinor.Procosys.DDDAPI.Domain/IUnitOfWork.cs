using System.Threading;
using System.Threading.Tasks;

namespace Equinor.Procosys.DDDAPI.Domain
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
