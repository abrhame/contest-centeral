using Application.Common.Models;
using Application.DTOs;
using MediatR;

namespace Application.Features.Contests.Commands;

public record CreateContestCommand( ContestDto CreateContest ) : IRequest<Result>;