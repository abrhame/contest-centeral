using MediatR;
using AutoMapper;

using Application.Common.Models;
using Application.Interfaces;
using Application.Features.Locations.Commands.Validator;
using Domain.Entity;

namespace Application.Features.Locations.Commands.Handler;

public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateLocationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
    {
        var UpdatedLocation = _mapper.Map<Location>(request.requestDto);
        
        var validationResult = await new UpdateLocationCommandValidator().ValidateAsync(request);

        if ( !validationResult.IsValid )
        {
            return Result.FailureResult(validationResult.Errors.Select(e => e.ErrorMessage));
        }

        var location = await _unitOfWork.LocationRepository.GetByLocationCodeAsync(request.requestDto.ShortName);

        if (location == null)
        {
            return Result.FailureResult(new string[] {$"Location with code {request.requestDto.ShortName} does not exist"});
        }

        location.ShortName = request.requestDto.ShortName ?? location.ShortName;
        location.City = request.requestDto.City ?? location.City;
        location.Country = request.requestDto.Country ?? location.Country;
        location.University = request.requestDto.University ?? location.University;

        await _unitOfWork.LocationRepository.UpdateAsync(location);
        await _unitOfWork.CommitAsync();

        return Result.SuccessResult("Location was updated successfully");
    }
}
