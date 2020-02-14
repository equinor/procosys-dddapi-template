using System.Linq;

namespace Equinor.Procosys.DDDAPI.Infrastructure
{
    public interface IReadOnlyContext
    {
        IQueryable<TEntity> QuerySet<TEntity>() where TEntity : class;
    }
}
