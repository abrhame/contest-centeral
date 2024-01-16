using MediatR;
using Application.Common.Models;
using Application.DTOs;

namespace Application.Features.Auth.Commands;

public record ResetPasswordCommand(ResetPasswordRequestDto Request, string token) : IRequest<Result>;
