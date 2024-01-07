using MediatR;

using Application.DTOs;
using Application.Common.Models;

namespace Application.Features.Locations.Commands;

public record UpdateLocationCommand(Guid Id, UpdateLocationRequestDto requestDto ) : IRequest<Result>;
