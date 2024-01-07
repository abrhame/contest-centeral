using MediatR;

using Application.DTOs;
using Application.Common.Models;

namespace Application.Features.Locations.Requests;

public class GetAllLocationsRequest : IRequest<(Result, List<LocationResponseDto>?)>;
