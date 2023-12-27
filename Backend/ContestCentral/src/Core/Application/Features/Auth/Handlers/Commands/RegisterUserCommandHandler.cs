using MediatR;

using ContestCentral.Application.Features.Auth.Requests;
using ContestCentral.Application.Common.Models;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Result> {
    public async Task<Result> Handle ( RegisterUserCommand request, CancellationToken cancellationToken ) {
        throw new NotImplementedException();
    }
}
