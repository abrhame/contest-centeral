using MediatR;

using ContestCentral.Application.Common.Models;

namespace ContestCentral.Application.Features.Auth.Requests;

public record ForgotPasswordRequest ( string Email ) : IRequest<Result>;
