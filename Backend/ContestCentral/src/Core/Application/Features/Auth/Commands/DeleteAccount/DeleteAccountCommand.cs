using MediatR;

using Application.Common.Models;

namespace Application.Features.Auth.Commands;

public record DeleteAccountCommand(Guid Id) : IRequest<Result>;

