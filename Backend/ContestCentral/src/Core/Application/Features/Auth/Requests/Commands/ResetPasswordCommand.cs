using MediatR;

using ContestCentral.Application.Common.Models;

namespace ContestCentral.Application.Features.Auth.Requests;

public record ResetPasswordCommand(string token, Guid userId) : IRequest<Result>;

