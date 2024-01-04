using MediatR;

using Application.Interfaces;

namespace Application.Features.Auth.Requests.Handlers;

public class LogoutRequestHandler : IRequestHandler<LogoutRequest, Unit>
{
    
    private readonly IAuthService _authService;

    public LogoutRequestHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<Unit> Handle(LogoutRequest request, CancellationToken cancellationToken)
    {
        await _authService.LogoutAsync();
        return Unit.Value;
    }
}
