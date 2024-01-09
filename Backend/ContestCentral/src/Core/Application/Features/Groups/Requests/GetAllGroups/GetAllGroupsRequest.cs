using MediatR;
using Application.Common.Models;
using Application.DTOs;

namespace Application.Features.Groups.GetAllGroups;

public record GetAllGroupsRequest() : IRequest<(Result, List<GroupResponseDto>)>;
