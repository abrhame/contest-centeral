using MediatR;
using AutoMapper;

using Application.DTOs;
using Application.Interfaces;
using Application.Common.Models;

namespace Application.Features.Locations.Requests.Handler;

public class GetLocationRequestHandler : IRequestHandler<GetLocationRequest, (Result, LocationResponseDto?)>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetLocationRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<(Result, LocationResponseDto?)> Handle(GetLocationRequest request, CancellationToken cancellationToken)
    {
        var location = await _unitOfWork.LocationRepository.GetByIdAsync(request.LocationId);

        if (location == null)
        {
            return (Result.FailureResult(new List<string> { "Location does not exist" }), null);
        }

        var locationDto = _mapper.Map<LocationResponseDto>(location);

        return (Result.SuccessResult("Location found successfully"), locationDto);

    }
}
