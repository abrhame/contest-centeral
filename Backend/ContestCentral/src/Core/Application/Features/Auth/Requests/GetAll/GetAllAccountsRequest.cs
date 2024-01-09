using MediatR;

using Application.DTOs;
using Application.Common.Models;

namespace Application.Features.Account.Requests;

public record GetAllAccountsRequest : IRequest<(Result, IEnumerable<UserResponseDto>)>;
