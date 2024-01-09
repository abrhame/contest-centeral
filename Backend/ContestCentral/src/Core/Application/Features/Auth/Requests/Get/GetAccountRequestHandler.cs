using MediatR;
using AutoMapper;

using Application.DTOs;
using Application.Common.Models;
using Application.Interfaces;

namespace Application.Features.Account.Requests.Handlers;

public class GetAccountRequestHandler : IRequestHandler<GetAccountRequest, (Result, UserResponseDto?)>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAccountRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<(Result, UserResponseDto?)> Handle(GetAccountRequest request, CancellationToken cancellationToken)
    {
        var account = await _unitOfWork.UserRepository.GetByIdAsync(request.Id);
        return account == null
            ? (Result.FailureResult(new List<string> { "Account does not exist" }), null)
            : (Result.SuccessResult("Success"), _mapper.Map<UserResponseDto>(account));
    }
}
