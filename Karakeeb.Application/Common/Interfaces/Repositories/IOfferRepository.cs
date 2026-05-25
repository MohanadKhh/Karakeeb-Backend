using Karakeeb.Domain;

namespace Karakeeb.Application;
public interface IOfferRepository : IRepository<Offer>
{
    Task<IReadOnlyList<Offer>> GetAllWithIncludesAsync(CancellationToken cancellationToken = default);
    Task<Offer?> GetByIdWithIncludesAsync(int id, CancellationToken cancellationToken = default);
}
