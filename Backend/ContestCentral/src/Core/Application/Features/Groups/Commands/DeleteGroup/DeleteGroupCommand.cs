using MediatR;
using Application.Common.Models;

namespace Application.Features.Groups.DeleteCommand;

public record DeleteGroupCommand(Guid GroupId) : IRequest<Result>;
