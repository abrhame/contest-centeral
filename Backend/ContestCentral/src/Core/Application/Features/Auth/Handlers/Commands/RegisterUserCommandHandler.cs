using MediatR;

using ContestCentral.Application.Features.Auth.Requests;
using ContestCentral.Application.Common.Models;
using ContestCentral.Application.Common.Interfaces;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Result> {
    private readonly IAuthService _authService;

    public RegisterUserCommandHandler( IAuthService authService ) {
        _authService = authService;
    }

    public async Task<Result> Handle ( RegisterUserCommand request, CancellationToken cancellationToken ) {
        return await _authService.RegisterAsync(request.requestDto);
    }
}
