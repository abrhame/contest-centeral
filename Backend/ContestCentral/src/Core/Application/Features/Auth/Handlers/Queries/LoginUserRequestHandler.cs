using MediatR;
using AutoMapper;

using ContestCentral.Application.Features.Auth.Requests;
using ContestCentral.Application.Common.DTOs;
using ContestCentral.Application.Common.Models;
using ContestCentral.Application.Common.Interfaces;

namespace ContestCentral.Application.Features.Auth.Handlers;

public class LoginUserRequestHandler : IRequestHandler<LoginUserRequest, (Result, AuthResponseDto?)> {
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public LoginUserRequestHandler ( ITokenService tokenService, IMapper mapper, IUnitOfWork unitOfWork ) {
        _tokenService = tokenService;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<(Result, AuthResponseDto?)> Handle ( LoginUserRequest request, CancellationToken cancellationToken ) {
        if ( request.Email is null || request.Password is null ) {
            return (Result.FailureResult(new string[] {"Email or password cannot be null"}), null);
        }

        var user = await _unitOfWork.UserRepository.GetUserByEmailAsync(request.Email);

        if ( user is null ) {
            return (Result.FailureResult(new string[] {"User does not exist"}), null);
        };

        if ( user.EmailVerified == null ) {
            return (Result.FailureResult(new string[] {"Email is not confirmed"}), null);
        }

        throw new NotImplementedException();
    }
}
