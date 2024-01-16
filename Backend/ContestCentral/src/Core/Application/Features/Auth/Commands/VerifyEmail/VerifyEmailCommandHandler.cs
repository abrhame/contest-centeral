using MediatR;

using Application.Common.Models;
using Application.Interfaces;
using Application.Features.Auth.Commands.Validator;

namespace Application.Features.Auth.Commands.Handler;

public class VerifyEmailCommandHandler : IRequestHandler<VerifyEmailCommand, Result>
{
    private readonly IAuthService _authService;
    private readonly ITokenService _tokenService;

    public VerifyEmailCommandHandler(IAuthService authService, ITokenService tokenService)
    {
        _authService = authService;
        _tokenService = tokenService;
    }

    public async Task<Result> Handle(VerifyEmailCommand request, CancellationToken cancellationToken)
    {
        var validator = new VerifyEmailCommandValidator();

        var validationResult = await validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return Result.FailureResult(new List<string>(validationResult.Errors.Select(e => e.ErrorMessage)));
        }

        var result = await _authService.VerifyEmailAsync(request.Token);

        if (result.Success)
        {
            return Result.SuccessResult("Email verified successfully");
        }

        return Result.FailureResult(result.Errors ?? new List<string>());
    }
}
