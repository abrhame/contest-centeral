using MediatR;

using ContestCentral.Application.Features.Auth.Requests;
using ContestCentral.Application.Common.Models;
using ContestCentral.Application.Common.Interfaces;

namespace ContestCentral.Application.Features.Auth.Commands;

public class VerifyEmailCommandHandler : IRequestHandler<VerifyEmailCommand, Result> {
    private readonly IAuthService _authService;

    public VerifyEmailCommandHandler ( IAuthService authService) {
        _authService = authService;
    }

    public async Task<Result> Handle ( VerifyEmailCommand request, CancellationToken cancellationToken ) {
        return await _authService.VerifyEmailAsync(request.token);
    }
}
