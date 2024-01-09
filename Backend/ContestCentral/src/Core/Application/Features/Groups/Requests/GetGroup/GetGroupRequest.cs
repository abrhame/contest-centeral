using MediatR;
using Application.Common.Models;
using Application.DTOs;

namespace Application.Features.Groups.GetGroup;

public record GetGroupRequest(Guid GroupId) : IRequest<(Result, GroupResponseDto)>;
