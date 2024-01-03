using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

using Application.DTOs;
using Application.Common.Models;
using Application.Interfaces;
using Domain.Entity;
using Infrastructure.Persistence;

namespace Infrastructure.Auth;

public class AuthService : IAuthService
{
    private readonly IMapper _mapper;
    private readonly ContestCentralDbContext _context;
    private readonly ITokenService _tokenService;
    private readonly IPasswordService _passwordService;
    private readonly IEmailService _emailService;
    private readonly ILogger _logger;

    public AuthService( 
            IMapper mapper, 
            ContestCentralDbContext context, 
            ITokenService tokenService, 
            IPasswordService passwordService, 
            IEmailService emailService,    
            ILogger logger
            ) 
    {
        _mapper = mapper;
        _context = context;
        _tokenService = tokenService;
        _passwordService = passwordService;
        _emailService = emailService;
        _logger = logger;
    }

    public Task<(Result, User)> LoginAsync(LoginUserRequestDto request)
    {
        throw new NotImplementedException();
    }

    public async Task<Result> RegisterAsync(RegisterUserRequestDto request)
    {
        var findGroup = await _context.Groups.FirstOrDefaultAsync(x => x.ShortName == request.GroupShortName);

        if (findGroup == null)
        {
            _logger.Error($"Group not found");
            return Result.FailureResult(new List<string> { "Group not found" });
        }


        var userExist = await _context.Users.AnyAsync(x => x.Email == request.Email);


        if (userExist)
        {
            _logger.Error($"User with email {request.Email} already exist");
            return Result.FailureResult(new List<string> { $"User with email {request.Email} already exist" });
        }

        var user = _mapper.Map<User>(request);
        user.PasswordHashed = _passwordService.HashPassword(request.Password);
        user.Group = findGroup;

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        await _emailService.SendAsync(new EmailRequest (
                        new string[] { request.Email },
                        "Verify Email Address",
                        $@"Please verify your email by clicking on the link below <br/> <a href=""{request.Email}"">Verify Email</a>"
                    ));

        return Result.SuccessResult("User Registered Successfully");
    }

    public Task<Unit> LogoutAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Result> VerifyEmailAsync(string code)
    {
        throw new NotImplementedException();
    }

    public Task<Result> ForgotPasswordAsync(string email)
    {
        throw new NotImplementedException();
    }

    public Task<Result> ResetPasswordAsync(ResetPasswordRequestDto request)
    {
        throw new NotImplementedException();
    }

    public Task<Result> UpdateProfileAsync(RegisterUserRequestDto request)
    {
        throw new NotImplementedException();
    }

    public Task<Result> getUserProfileAsync(Guid userId)
    {
        throw new NotImplementedException();
    }
}
