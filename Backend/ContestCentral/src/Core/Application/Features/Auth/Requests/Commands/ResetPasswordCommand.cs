using MediatR;

using ContestCentral.Application.Common.Models;
using ContestCentral.Application.Common.DTOs;

namespace ContestCentral.Application.Features.Auth.Requests;

public record ResetPasswordCommand(string token, ResetPasswordRequestDto ResetPasswordRequestDto) : IRequest<Result>;

