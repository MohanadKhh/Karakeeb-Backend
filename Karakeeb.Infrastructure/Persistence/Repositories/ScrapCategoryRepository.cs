using Karakeeb.Application;
using Karakeeb.Domain;
using Microsoft.EntityFrameworkCore;

namespace Karakeeb.Infrastructure;

public class ScrapCategoryRepository : Repository<ScrapCategory>, IScrapCategoryRepository
{
    public ScrapCategoryRepository(AppDbContext context) : base(context)
    {
    }
    public async Task<IReadOnlyList<ScrapCategory>> GetAllWithItemsAsync(CancellationToken cancellationToken = default)
    {
        return await _context.ScrapCategories
            .AsNoTracking()
            .Include(c => c.ScrapItems)
            .ToListAsync(cancellationToken);
    }

    public async Task<ScrapCategory?> GetByIdWithItemsAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.ScrapCategories
            .AsNoTracking()
            .Include(c => c.ScrapItems)
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
    }
}
