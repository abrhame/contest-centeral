using MediatR;

using ContestCentral.Application.Features.Auth.Requests;
using ContestCentral.Application.Common.Models;

namespace ContestCentral.Application.Features.Auth.Commands;

public class ForgotPasswordRequestHandler : IRequestHandler<ForgotPasswordRequest, Result> {
    public async Task<Result> Handle ( ForgotPasswordRequest request, CancellationToken cancellationToken ) {
        throw new NotImplementedException();
    }
}
