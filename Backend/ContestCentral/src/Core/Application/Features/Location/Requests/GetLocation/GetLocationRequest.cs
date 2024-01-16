using MediatR;

using Application.DTOs;
using Application.Common.Models;

namespace Application.Features.Locations.Requests;

public record GetLocationRequest(Guid LocationId) : IRequest<(Result, LocationResponseDto?)>;
