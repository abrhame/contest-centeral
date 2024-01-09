using MediatR;
using Application.Common.Models;
using Application.DTOs;

namespace Application.Features.Groups.CreateGroup;

public record CreateGroupCommand( CreateGroupRequestDto CreateGroup ) : IRequest<Result>;

