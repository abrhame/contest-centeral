using MediatR;
using AutoMapper;

using Application.Common.Models;
using Application.Interfaces;
using Application.Features.Auth.Commands.Validator;

namespace Application.Features.Auth.Commands.Handler;

public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand, Result>
{
    private readonly IAuthService _authService;
    private readonly IMapper _mapper;

    public ForgotPasswordCommandHandler(IAuthService authService, IMapper mapper)
    {
        _authService = authService;
        _mapper = mapper;
    }

    public async Task<Result> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
    {
        var validator = new ForgotPasswordCommandValidator();

        var validationResult = await validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return Result.FailureResult(new List<string>(validationResult.Errors.Select(e => e.ErrorMessage)));
        }

        var result = await _authService.ForgotPasswordAsync(request.Email);

        if (result.Success)
        {
            return Result.SuccessResult("Forgot password email sent successfully");
        }

        return Result.FailureResult(result.Errors ?? new List<string>());
    }
}
