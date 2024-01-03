using MediatR;

using Application.Common.Models;
using Application.Interfaces;
using Application.Features.Auth.Commands.Validator;

namespace Application.Features.Auth.Commands.Handler;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Result>
{
    private readonly IAuthService _authService;

    public RegisterUserCommandHandler(
            IAuthService authService
           )
    {
        _authService = authService;
    }

    public async Task<Result> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await new RegisterUserCommandValidator().ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return Result.FailureResult(new List<string>(validationResult.Errors.Select(e => e.ErrorMessage)));
        }

        var result = await _authService.RegisterAsync(request.Request);

        if (result.Success)
        {
            return Result.SuccessResult("User Registered Successfully");
        }

        return Result.FailureResult(result.Errors ?? new List<string>());
    }
}
