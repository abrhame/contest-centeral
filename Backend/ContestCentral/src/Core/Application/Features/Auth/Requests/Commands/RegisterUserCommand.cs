using MediatR;

using ContestCentral.Application.Common.Models;
using ContestCentral.Application.Common.DTOs;

namespace ContestCentral.Application.Features.Auth.Requests;

public record RegisterUserCommand ( RegisterUserRequestDto requestDto ) : IRequest<Result>;
