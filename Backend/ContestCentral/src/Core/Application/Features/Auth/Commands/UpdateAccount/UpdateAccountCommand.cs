using MediatR;

using Application.DTOs;
using Application.Common.Models;

namespace Application.Features.Auth.Commands;

public record UpdateAccountCommand(Guid Id, UpdateUserRequestDto UpdateUserRequestDto ) : IRequest<Result>; 
