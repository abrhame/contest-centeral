using MediatR;
using AutoMapper;
using Application.Common.Models;
using Application.Interfaces;
using Domain.Entity;

using Application.Features.Groups.CreateGroup.Validator;

namespace Application.Features.Groups.CreateGroup.Handler;

public class CreateGroupCommandHandler : IRequestHandler<CreateGroupCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateGroupCommandHandler( IUnitOfWork unitOfWork, IMapper mapper )
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result> Handle( CreateGroupCommand request, CancellationToken cancellationToken)
    {
        var validatorResult = await new CreateGroupCommandValidator().ValidateAsync(request, cancellationToken);

        if (!validatorResult.IsValid)
        {
            return Result.FailureResult(validatorResult.Errors.Select(e => e.ErrorMessage));
        }

        var group = _mapper.Map<Group>(request.CreateGroup.GroupDto);

        var location = await _unitOfWork.LocationRepository.GetByLocationCodeAsync(request.CreateGroup.LocationCode);

        if (location is null)
        {
            return Result.FailureResult(new List<string> { "Location does not exist" });
        }
        
        group.Location = location;

        await _unitOfWork.GroupRepository.AddAsync(group);

        await _unitOfWork.CommitAsync();

        return Result.SuccessResult("Group created successfully");
    }
}
