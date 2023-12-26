using MediatR;

using ContestCentral.Application.Common.DTOs;
using ContestCentral.Application.Common.Models;

namespace ContestCentral.Application.Features.Auth.Requests;

public record RegisterUserCommand ( RegisterUserRequestDto Request ) : IRequest<Result>;
