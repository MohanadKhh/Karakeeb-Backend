
using MediatR;
namespace Karakeeb.Application;

public sealed record CreateScrapItemCommand(CreateScrapItemDto createScrapItemDto) : IRequest<GeneralResult>;

public class CreateScrapItemCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<CreateScrapItemCommand, GeneralResult>
{
    public Task<GeneralResult> Handle(CreateScrapItemCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
