using MediatR;

using ContestCentral.Application.Common.DTOs;
using ContestCentral.Application.Common.Models;

namespace ContestCentral.Application.Features.Auth.Requests;

public record VerifyEmailCommand( string token, Guid userId ) : IRequest<(Result, AuthResponseDto?)>;
