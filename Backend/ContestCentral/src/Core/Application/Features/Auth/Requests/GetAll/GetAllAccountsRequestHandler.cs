using MediatR;
using AutoMapper;

using Application.DTOs;
using Application.Common.Models;
using Application.Interfaces;

namespace Application.Features.Account.Requests.Handlers;

public class GetAllAccountsRequestHandler : IRequestHandler<GetAllAccountsRequest, (Result, IEnumerable<UserResponseDto>)>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllAccountsRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<(Result, IEnumerable<UserResponseDto>)> Handle(GetAllAccountsRequest request, CancellationToken cancellationToken)
    {
        var accounts = await _unitOfWork.UserRepository.GetAllAsync();
        return (Result.SuccessResult("Successful"), _mapper.Map<IEnumerable<UserResponseDto>>(accounts));
    }
}
