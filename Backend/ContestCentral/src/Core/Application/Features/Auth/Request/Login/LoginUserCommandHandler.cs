using MediatR;
using AutoMapper;

using Application.Common.Models;
using Application.Interfaces;
using Application.DTOs;
using Application.Features.Auth.Commands.Validator;

namespace Application.Features.Auth.Commands.Handler;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, (Result, AuthResponseDto?)>
{
    private readonly IAuthService _authService;
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;

    public LoginUserCommandHandler(IAuthService authService, ITokenService tokenService, IMapper mapper)
    {
        _authService = authService;
        _tokenService = tokenService;
        _mapper = mapper;
    }

    public async Task<(Result, AuthResponseDto?)> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var validator = new LoginUserCommandValidator();

        var validationResult = await validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return (Result.FailureResult(new List<string>(validationResult.Errors.Select(e => e.ErrorMessage))), null);
        }

        var (result, response) = await _authService.LoginAsync(request.Request);

        if (result.Success)
        {
            return (
                    Result.SuccessResult("User Registered Successfully"),
                    new AuthResponseDto (
                        accessToken: _tokenService.GenerateAccessToken(response),
                        refreshToken: _tokenService.GenerateRefreshToken().Item2,
                        user: _mapper.Map<UserDto>(response)
                        )
                    );

        }

        return (Result.FailureResult(result.Errors ?? new List<string>()), null);
    }
}
