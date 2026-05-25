using Karakeeb.Application;
using Karakeeb.Domain;
using Microsoft.EntityFrameworkCore;

namespace Karakeeb.Infrastructure;

public class OfferRepository : Repository<Offer>, IOfferRepository
{
    public OfferRepository(AppDbContext _context) : base(_context)
    {
    }

    public async Task<IReadOnlyList<Offer>> GetAllWithIncludesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Offers
            .AsNoTracking()
            .Include(o => o.ScrapItem)
            .Include(o => o.Deal)
            .ToListAsync(cancellationToken);
    }

    public async Task<Offer?> GetByIdWithIncludesAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Offers
            .AsNoTracking()
            .Include(o => o.ScrapItem)
            .Include(o => o.Deal)
            .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
    }
}
