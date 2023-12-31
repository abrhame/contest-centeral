using MediatR;

using ContestCentral.Application.Common.DTOs; 
using ContestCentral.Application.Common.Models;

namespace ContestCentral.Application.Features.Auth.Commands;

public record RefreshTokenCommand(string Token) : IRequest<(Result, AuthResponseDto?)>;
