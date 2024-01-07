using MediatR;

using Application.Interfaces;

namespace Application.Features.Auth.Requests.Handlers;

public class LogoutRequestHandler : IRequestHandler<LogoutRequest, Unit>
{
    
    private readonly IAuthService _authService;
    private readonly ITokenService _tokenService;
    private readonly IUnitOfWork _unitOfWork;

    public LogoutRequestHandler(IAuthService authService, ITokenService tokenService, IUnitOfWork unitOfWork)
    {
        _authService = authService;
        _tokenService = tokenService;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(LogoutRequest request, CancellationToken cancellationToken)
    {
        var IsValid = _tokenService.ValidateToken(request.RefreshToken, out var tokenId);

        if (!IsValid)
        {
            throw new HttpRequestException("Invalid token");
        }

        var token = await _unitOfWork.TokenRepository.GetByIdAsync(tokenId);

        if (token != null)
        {
            await _unitOfWork.TokenRepository.DeleteAsync(token);
            await _unitOfWork.CommitAsync();
        }

        return Unit.Value;
    }
}
