using MediatR;

namespace Karakeeb.Application;

public sealed record GetScrapItemsQuery() : IRequest<GeneralResult<List<ScrapItemDto>>>;

public class GetScrapItemsQueryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetScrapItemsQuery, GeneralResult<List<ScrapItemDto>>>
{
    public async Task<GeneralResult<List<ScrapItemDto>>> Handle(GetScrapItemsQuery request, CancellationToken cancellationToken)
    {
        var scrapItems = await _unitOfWork.ScrapItemRepository.GetAllAsync(cancellationToken);
        var scrapItemsDtos = scrapItems.Select(si => si.ToScrapItemDto()).ToList();

        return GeneralResult<List<ScrapItemDto>>.SuccessedResult(scrapItemsDtos);
    }
}