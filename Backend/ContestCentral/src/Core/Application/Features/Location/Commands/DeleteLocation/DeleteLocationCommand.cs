using MediatR;
using Application.Common.Models;

namespace Application.Features.Locations.Commands;

public record DeleteLocationCommand(Guid LocationId): IRequest<Result>;
