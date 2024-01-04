using MediatR;
using Application.Common.Models;
using Application.DTOs;

namespace Application.Features.Auth.Commands;

public record RefreshTokenCommand(string Token) : IRequest<(Result, AuthResponseDto?)>;
