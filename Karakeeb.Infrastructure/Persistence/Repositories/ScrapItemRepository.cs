using Karakeeb.Application;
using Karakeeb.Domain;
using Microsoft.EntityFrameworkCore;

namespace Karakeeb.Infrastructure;

public class ScrapItemRepository : Repository<ScrapItem>, IScrapItemRepository
{
    public ScrapItemRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IReadOnlyList<ScrapItem>> GetAllWithIncludesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.ScrapItems
            .AsNoTracking()
            .Include(i => i.Category)
            .Include(i => i.Images)
            .Include(i => i.Offers)
            .ToListAsync(cancellationToken);
    }

    public async Task<ScrapItem?> GetByIdWithIncludesAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.ScrapItems
            .AsNoTracking()
            .Include(i => i.Category)
            .Include(i => i.Images)
            .Include(i => i.Offers)
            .FirstOrDefaultAsync(i => i.Id == id, cancellationToken);
    }
}
