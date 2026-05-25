using Karakeeb.Domain;

namespace Karakeeb.Application;
public interface IScrapItemRepository : IRepository<ScrapItem>
{
    Task<IReadOnlyList<ScrapItem>> GetAllWithIncludesAsync(CancellationToken cancellationToken = default);
    Task<ScrapItem?> GetByIdWithIncludesAsync(int id, CancellationToken cancellationToken = default);
}
