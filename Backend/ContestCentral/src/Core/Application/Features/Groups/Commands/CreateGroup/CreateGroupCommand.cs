using MediatR;
using Application.Common.Models;
using Application.DTOs;

namespace Application.Features.Groups.CreateGroup;

public record CreateGroupCommand( CreateGroupDto CreateGroup ) : IRequest<Result>;

