using MediatR;
using Application.Common.Models;
using Domain.Entity;

namespace Application.Features.Groups.DeleteCommand;

public record DeleteGroupCommand( Group Group ) : IRequest<Result>;
