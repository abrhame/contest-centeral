using Application.Interfaces;
using Application.Common.Models;
using Domain.Entity;

using AutoMapper;
using MediatR;

namespace Application.Features.Groups.UpdateGroup.Handler;

public class UpdateGroupCommandHandler : IRequestHandler<UpdateGroupCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateGroupCommandHandler( IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result> Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
    {
        var group = await _unitOfWork.GroupRepository.GetByIdAsync(request.Id);

        if (group == null)
        {
            return Result.FailureResult(new List<string> {"Group does not exist"});
        }

        group = _mapper.Map<Group>(request.GroupDto.GroupInfo);

        await _unitOfWork.GroupRepository.UpdateAsync(group);

        return Result.SuccessResult("Group updated successfully");
    }
}
