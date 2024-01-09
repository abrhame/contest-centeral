using MediatR;
using AutoMapper;
using Application.Interfaces;
using Domain.Entity;
using Application.Common.Models;

using Application.Features.Locations.Commands.Validator;

namespace Application.Features.Locations.Commands.Handler;

public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateLocationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await new CreateLocationCommandValidator().ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return Result.FailureResult(validationResult.Errors.Select(e => e.ErrorMessage));
        }

        var locationExist = await _unitOfWork.LocationRepository.GetByLocationCodeAsync(request.request.ShortName);

        if (locationExist != null)
        {
            return Result.FailureResult(new string[] {"Location already exist"});
        }

        var location = _mapper.Map<Location>(request.request);
        await _unitOfWork.LocationRepository.AddAsync(location);
        await _unitOfWork.CommitAsync();
        return Result.SuccessResult("Location was created successfully");
    }
}

