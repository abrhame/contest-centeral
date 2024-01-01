using MediatR;

namespace Application.Features.Auth.Requests;

public record LogoutRequest : IRequest<Unit>;
