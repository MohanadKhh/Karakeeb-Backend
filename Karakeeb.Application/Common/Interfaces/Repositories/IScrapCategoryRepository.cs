using Karakeeb.Domain;

namespace Karakeeb.Application;

public interface IScrapCategoryRepository : IRepository<ScrapCategory>
{
    Task<IReadOnlyList<ScrapCategory>> GetAllWithItemsAsync(CancellationToken cancellationToken = default);
    Task<ScrapCategory?> GetByIdWithItemsAsync(int id, CancellationToken cancellationToken = default);
}
