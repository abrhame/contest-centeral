using MediatR;

using ContestCentral.Application.Common.DTOs;
using ContestCentral.Application.Common.Models;

namespace ContestCentral.Application.Features.Auth.Requests;

public record LoginUserRequest ( string Email, string Password ) : IRequest<(Result, AuthResponseDto?)>;
