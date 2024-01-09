using MediatR;

namespace Application.Features.Auth.Requests;

public record LogoutRequest(string RefreshToken) : IRequest<Unit>;
