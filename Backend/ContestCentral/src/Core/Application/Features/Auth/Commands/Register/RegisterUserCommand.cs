using MediatR;

using Application.DTOs;
using Application.Common.Models;

namespace Application.Features.Auth.Commands;

public record RegisterUserCommand( RegisterUserRequestDto Request ) : IRequest<Result>;
