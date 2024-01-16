using MediatR;
using Application.Common.Models;

namespace Application.Features.Auth.Commands;

public record VerifyEmailCommand(string Token) : IRequest<Result>;
