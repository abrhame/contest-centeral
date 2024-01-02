using MediatR;
using AutoMapper;

using Application.DTOs;
using Application.Common.Models;
using Application.Interfaces;


namespace Application.Features.Groups.GetAllGroups.Handler;

public class GetAllGroupsRequestHandler : IRequestHandler<GetAllGroupsRequest, (Result, List<GroupDto>)>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;  

    public GetAllGroupsRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<(Result, List<GroupDto>)> Handle(GetAllGroupsRequest request, CancellationToken cancellationToken)
    {
        var groups = await _unitOfWork.GroupRepository.GetAllAsync();

        var response = _mapper.Map<List<GroupDto>>(groups);

        return (Result.SuccessResult("Successful"), response);
    }
}
