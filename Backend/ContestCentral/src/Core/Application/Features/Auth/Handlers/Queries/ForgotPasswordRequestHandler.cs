using MediatR;

using ContestCentral.Application.Features.Auth.Requests;
using ContestCentral.Application.Common.Models;
using ContestCentral.Application.Common.Interfaces;

namespace ContestCentral.Application.Features.Auth.Commands;

public class ForgotPasswordRequestHandler : IRequestHandler<ForgotPasswordRequest, Result> {
    private readonly IAuthService _authService;
    public ForgotPasswordRequestHandler ( IAuthService authService) {
        _authService = authService;
    }

    public async Task<Result> Handle ( ForgotPasswordRequest request, CancellationToken cancellationToken ) {
        return await _authService.ForgotPasswordAsync(request.Email);
    }
}
