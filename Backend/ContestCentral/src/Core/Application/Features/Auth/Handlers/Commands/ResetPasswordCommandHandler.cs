using MediatR;

using ContestCentral.Application.Features.Auth.Requests;
using ContestCentral.Application.Common.Models;
using ContestCentral.Application.Common.Interfaces;

namespace ContestCentral.Application.Features.Auth.Handlers;

public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, Result> {
    private readonly IAuthService _authService;

    public ResetPasswordCommandHandler( IAuthService authService ) {
        _authService = authService;
    }

    public Task<Result> Handle(ResetPasswordCommand request, CancellationToken cancellationToken) {
        return _authService.ResetPasswordAsync(request.token, request.userId);
    }
} 

