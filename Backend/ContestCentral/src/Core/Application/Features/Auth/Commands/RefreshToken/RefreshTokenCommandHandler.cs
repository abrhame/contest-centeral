using MediatR;
using AutoMapper;

using Application.Common.Models;
using Application.DTOs;
using Application.Interfaces;
using Domain.Entity;

namespace Application.Features.Auth.Commands.Handler;

public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, (Result, AuthResponseDto?)>
{
    private readonly IAuthService _authService;
    private readonly IMapper _mapper;
    private readonly ITokenService _tokenService;
    private readonly IUnitOfWork _unitOfWork;


    public RefreshTokenCommandHandler(IAuthService authService, IMapper mapper, ITokenService tokenService, IUnitOfWork unitOfWork)
    {
        _authService = authService;
        _mapper = mapper;
        _tokenService = tokenService;
        _unitOfWork = unitOfWork;
    }

    public async Task<(Result, AuthResponseDto?)> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var (result, user) = await _authService.RefreshTokenAsync(request.Token);

        if (!result.Success)
        {
            return (result, null);
        }

        var (newRefreshTokenId, newRefreshToken) = _tokenService.GenerateRefreshToken();

        if (user is null)
        {
            return (Result.FailureResult(new string[] {"Invalid Token"}), null);
        }

        var tokendb = await _unitOfWork.TokenRepository.GetByTokenAsync(request.Token);

        if (tokendb is null)
        {
            return (Result.FailureResult(new string[] {"Invalid Token"}), null);
        }

        await _unitOfWork.TokenRepository.DeleteAsync(tokendb);
        
        var token = new Token
        {
            Id = newRefreshTokenId,
            UserId = user.Id,
            User = user,
            RefreshToken = newRefreshToken,
        };

        await _unitOfWork.TokenRepository.AddAsync(token);

        await _unitOfWork.CommitAsync();

        var userResponse = _mapper.Map<UserDto>(user);

        var authResponse = new AuthResponseDto (_tokenService.GenerateAccessToken(user), userResponse, newRefreshToken);

        return (Result.SuccessResult("Successfully refreshed token"), authResponse);

    }
}
