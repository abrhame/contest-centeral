using MediatR;
using Application.Common.Models;

namespace Application.Features.Auth.Commands;

public record ForgotPasswordCommand( string Email ) : IRequest<Result>;
