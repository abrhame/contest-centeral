using MediatR;

using ContestCentral.Application.Common.Models;
using ContestCentral.Domain.Constants;

namespace ContestCentral.Application.Features.Auth.Requests;

public record RegisterUserCommand ( string UserName, string FirstName, string LastName, string Email, string Password, Role Role, string PhoneNumber) : IRequest<Result>;
