using MediatR;

using ContestCentral.Application.Features.Auth.Requests;
using ContestCentral.Application.Common.DTOs;
using ContestCentral.Application.Common.Models;
using ContestCentral.Application.Common.Interfaces;

namespace ContestCentral.Application.Features.Auth.Handlers;

public class LoginUserRequestHandler : IRequestHandler<LoginUserRequest, (Result, AuthResponseDto?)> {
    private readonly IAuthService _authService;

    public LoginUserRequestHandler ( IAuthService authService) {
        _authService = authService;
    }

    public async Task<(Result, AuthResponseDto?)> Handle ( LoginUserRequest request, CancellationToken cancellationToken ) {
        return await _authService.LoginAsync(request.RequestDto);
    }
}
