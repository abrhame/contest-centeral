using MediatR;
using AutoMapper;

using Application.DTOs; 
using Application.Common.Models;
using Application.Interfaces;

namespace Application.Features.Groups.GetGroup.Handler;

public class GetGroupRequestHandler : IRequestHandler<GetGroupRequest, (Result, GroupDto)>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetGroupRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<(Result, GroupDto)> Handle(GetGroupRequest request, CancellationToken cancellationToken)
    {
        var group = await _unitOfWork.GroupRepository.GetByIdAsync(request.GroupId);

        if (group is null)
        {
            return (Result.FailureResult(new List<string> { "Group does not exist" }), null!);
        }

        var response = _mapper.Map<GroupDto>(group);

        return (Result.SuccessResult("Successful"), response);
    }
}
