using Karakeeb.Application;

namespace Karakeeb.Infrastructure;
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public IRepository<TEntity> Repository<TEntity>() where TEntity : class
    {
        return new Repository<TEntity>(_context);
    }

    public IScrapCategoryRepository ScrapCategoryRepository => new ScrapCategoryRepository(_context);

    public IScrapItemRepository ScrapItemRepository => new ScrapItemRepository(_context);

    public IOfferRepository OfferRepository => new OfferRepository(_context);

    public IDealRepository DealRepository => new DealRepository(_context);

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}
