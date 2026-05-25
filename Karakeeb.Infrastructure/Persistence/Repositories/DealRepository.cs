using Karakeeb.Application;
using Karakeeb.Domain;
using Microsoft.EntityFrameworkCore;

namespace Karakeeb.Infrastructure;

public class DealRepository : Repository<Deal>, IDealRepository
{
    public DealRepository(AppDbContext _context) : base(_context)
    {
    }

    public async Task<IReadOnlyList<Deal>> GetAllWithIncludesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Deals
            .AsNoTracking()
            .Include(d => d.Offer)
            .Include(d => d.ScrapItem)
            .ToListAsync(cancellationToken);
    }

    public async Task<Deal?> GetByIdWithIncludesAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Deals
            .AsNoTracking()
            .Include(d => d.Offer)
            .Include(d => d.ScrapItem)
            .FirstOrDefaultAsync(d => d.Id == id, cancellationToken);
    }
}
