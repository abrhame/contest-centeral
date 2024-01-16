using MediatR;
using AutoMapper;

using Application.Common.Models;
using Application.Interfaces;
using Application.DTOs;
using Application.Features.Auth.Commands.Validator;
using Domain.Entity;

namespace Application.Features.Auth.Commands.Handler;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, (Result, AuthResponseDto?)>
{
    private readonly IAuthService _authService;
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public LoginUserCommandHandler(IAuthService authService, ITokenService tokenService, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _authService = authService;
        _tokenService = tokenService;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<(Result, AuthResponseDto?)> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await new LoginUserCommandValidator().ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return (Result.FailureResult(new List<string>(validationResult.Errors.Select(e => e.ErrorMessage))), null);
        }

        var (result, response) = await _authService.LoginAsync(request.Request);

        if ( !result.Success || response == null )
        {
            return (Result.FailureResult(result.Errors ?? new List<string>()), null);
        }

        var AccessToken = _tokenService.GenerateAccessToken(response);
        var (TokenId, RefreshToken) = _tokenService.GenerateRefreshToken();

        await _unitOfWork.TokenRepository.AddAsync(new Token {
            Id = TokenId,
            RefreshToken = RefreshToken,
            User = response,
        });

        await _unitOfWork.CommitAsync();

        if (result.Success)
        {
            return (
                    Result.SuccessResult("User Registered Successfully"),
                    new AuthResponseDto (
                        AccessToken: AccessToken,
                        RefreshToken: RefreshToken,
                        User: _mapper.Map<UserResponseDto>(response)
                        )
                    );

        }

        return (Result.FailureResult(result.Errors ?? new List<string>()), null);
    }
}
