namespace Karakeeb.Application;

public interface IUnitOfWork
{
    IRepository<TEntity> Repository<TEntity>() where TEntity : class;
    IScrapCategoryRepository ScrapCategoryRepository { get; }
    IScrapItemRepository ScrapItemRepository { get; }
    IOfferRepository OfferRepository { get; }
    IDealRepository DealRepository { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
