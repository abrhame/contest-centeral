using MediatR;

using ContestCentral.Application.Features.Auth.Requests;
using ContestCentral.Application.Common.Models;
using ContestCentral.Application.Common.Interfaces;
using ContestCentral.Application.Common.DTOs;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Result> {
    private readonly IAuthService _authService;

    public RegisterUserCommandHandler( IAuthService authService ) {
        _authService = authService;
    }

    public async Task<Result> Handle ( RegisterUserCommand request, CancellationToken cancellationToken ) {
        var requestDto = new RegisterUserRequestDto {
            FirstName = request.FirstName,
            LastName = request.LastName,
            UserName = request.UserName,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            Password = request.Password,
            Role = request.Role
        };

        var result = await _authService.RegisterAsync(requestDto);

        return result;

    }
}
