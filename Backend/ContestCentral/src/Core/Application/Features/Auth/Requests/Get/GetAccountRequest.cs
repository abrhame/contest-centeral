using MediatR;

using Application.DTOs;
using Application.Common.Models;

namespace Application.Features.Account.Requests;

public record GetAccountRequest(Guid Id) : IRequest<(Result, UserResponseDto?)>;
