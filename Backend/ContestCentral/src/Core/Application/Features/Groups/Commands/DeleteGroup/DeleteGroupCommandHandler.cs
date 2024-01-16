using MediatR;
using AutoMapper;

using Application.Common.Models;
using Application.Interfaces;

namespace Application.Features.Groups.DeleteCommand.Handler;

public class DeleteGroupCommandHandler : IRequestHandler<DeleteGroupCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteGroupCommandHandler( IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result> Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
    {
        var group = await _unitOfWork.GroupRepository.GetByIdAsync(request.GroupId);

        if (group is null)
        {
            return Result.FailureResult(new List<string> { "Group does not exist" });
        }

        await _unitOfWork.GroupRepository.DeleteAsync(group);

        return Result.SuccessResult("Group deleted successfully");
    }
}
