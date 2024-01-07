using MediatR;
using Application.DTOs;
using Application.Common.Models;

namespace Application.Features.Groups.UpdateGroup;

public record UpdateGroupCommand(Guid Id, CreateGroupRequestDto GroupDto ) : IRequest<Result>;
