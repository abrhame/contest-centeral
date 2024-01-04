using MediatR;
using AutoMapper;

using Application.Common.Models;
using Application.Interfaces;

namespace Application.Features.Locations.Commands.Handler;

public class DeleteLocationCommandHandler : IRequestHandler<DeleteLocationCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteLocationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result> Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
    {
        var location = await _unitOfWork.LocationRepository.GetByIdAsync(request.LocationId);

        if (location != null)
        {
            await _unitOfWork.LocationRepository.DeleteAsync(location);
            await _unitOfWork.CommitAsync();
        }

        return Result.SuccessResult("Location was deleted successfully");
    }
}
