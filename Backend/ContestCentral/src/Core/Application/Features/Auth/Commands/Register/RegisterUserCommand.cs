using MediatR;

using Application.DTOs;
using Application.Common.Models;

namespace Application.Features.Auth.Commands;

public record RegisterUserCommand(CreateUserRequestDto Request) : IRequest<Result>;
