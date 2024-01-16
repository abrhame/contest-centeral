using MediatR;

using Application.Common.Models;
using Application.Interfaces;
using Application.Features.Auth.Commands.Validator;

namespace Application.Features.Auth.Commands.Handler;

public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, Result>
{
    private readonly IAuthService _authService;
    private readonly ITokenService _tokenService;

    public ResetPasswordCommandHandler(IAuthService authService, ITokenService tokenService)
    {
        _authService = authService;
        _tokenService = tokenService;
    }

    public async Task<Result> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        var validator = new ResetPasswordCommandValidator();

        var validationResult = await validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return Result.FailureResult(new List<string>(validationResult.Errors.Select(e => e.ErrorMessage)));
        }

        var result = await _authService.ResetPasswordAsync(request.Request, request.token);

        if (result.Success)
        {
            return Result.SuccessResult("Password reset successfully");
        }

        return Result.FailureResult(result.Errors ?? new List<string>());
    }
}
