using MediatR;

using Application.DTOs;
using Application.Common.Models;

namespace Application.Features.Locations.Commands;

public record UpdateLocationCommand( LocationDto requestDto ) : IRequest<Result>;
