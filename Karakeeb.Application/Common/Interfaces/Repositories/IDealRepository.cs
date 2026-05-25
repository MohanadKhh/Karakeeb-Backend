using Karakeeb.Domain;

namespace Karakeeb.Application;

public interface IDealRepository : IRepository<Deal>
{
    Task<IReadOnlyList<Deal>> GetAllWithIncludesAsync(CancellationToken cancellationToken = default);
    Task<Deal?> GetByIdWithIncludesAsync(int id, CancellationToken cancellationToken = default);
}
