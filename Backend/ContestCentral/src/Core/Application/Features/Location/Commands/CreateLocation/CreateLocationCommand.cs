using MediatR;
using Application.DTOs;
using Application.Common.Models;

namespace Application.Features.Locations.Commands;

public record CreateLocationCommand(CreateLocationRequestDto request) : IRequest<Result>;
