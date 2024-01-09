using MediatR;

using Application.Common.Models;
using Domain.Constant;

namespace Application.Features.Auth.Commands;

public record UpdateUserRoleCommand(Guid Id, Role NewRole) : IRequest<Result>;
