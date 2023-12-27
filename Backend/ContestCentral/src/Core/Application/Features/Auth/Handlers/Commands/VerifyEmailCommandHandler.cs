using MediatR;

using ContestCentral.Application.Features.Auth.Requests;
using ContestCentral.Application.Common.DTOs;
using ContestCentral.Application.Common.Models;

namespace ContestCentral.Application.Features.Auth.Commands;

public class VerifyEmailCommandHandler : IRequestHandler<VerifyEmailCommand, (Result, AuthResponseDto)> {
    public async Task<(Result, AuthResponseDto)> Handle ( VerifyEmailCommand request, CancellationToken cancellationToken ) {
        throw new NotImplementedException();
    }
}
