using MediatR;

namespace Karakeeb.Application;

public sealed record GetScrapItemById(int Id) : IRequest<GeneralResult>;

public class GetScrapItemByIdHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetScrapItemById, GeneralResult>
{
    public async Task<GeneralResult> Handle(GetScrapItemById request, CancellationToken cancellationToken)
    {
        var scrapItem = await _unitOfWork.ScrapItemRepository.GetByIdAsync(request.Id, cancellationToken);
        if (scrapItem == null)
        {
            return GeneralResult.FailedResult("Scrap item not found.");
        }

        var scrapItemDto = scrapItem.ToScrapItemDto();
        return GeneralResult<ScrapItemDto>.SuccessedResult(scrapItemDto);
    }
}
