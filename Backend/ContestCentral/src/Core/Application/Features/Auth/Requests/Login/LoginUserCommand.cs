using MediatR;
using Application.Common.Models;
using Application.DTOs;

namespace Application.Features.Auth.Commands;

public record LoginUserCommand( AuthRequestDto Request ) : IRequest<(Result, AuthResponseDto?)>;
