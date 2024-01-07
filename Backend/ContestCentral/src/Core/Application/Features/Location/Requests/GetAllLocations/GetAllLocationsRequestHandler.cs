using MediatR;
using AutoMapper;

using Application.Interfaces;
using Application.DTOs;
using Application.Common.Models;

namespace Application.Features.Locations.Requests.Handler;

public class GetAllLocationsRequestHandler : IRequestHandler<GetAllLocationsRequest, (Result, List<LocationResponseDto>?)>
{
    private readonly IUnitOfWork _unitOfWork; 
    private readonly IMapper _mapper;

    public GetAllLocationsRequestHandler( IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<(Result, List<LocationResponseDto>?)> Handle(GetAllLocationsRequest request, CancellationToken cancellationToken)
    {
        var locations = await _unitOfWork.LocationRepository.GetAllAsync();
        
        if (locations == null)
        {
            return (Result.FailureResult(new List<string> { "No locations found" }), null);
        }

        var locationsDto = _mapper.Map<List<LocationResponseDto>>(locations);

        return (Result.SuccessResult("Locations found successfully"), locationsDto);
    }
}
