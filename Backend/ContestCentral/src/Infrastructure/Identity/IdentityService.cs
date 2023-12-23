using ContestCentral.Infrastructure.Identity.Models;
using ContestCentral.Application.Interfaces;
using ContestCentral.Application.Common.Models;
using ContestCentral.Application.Common.DTOs;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace ContestCentral.Infrastructure.Identity;

public class IdentityService: IIdentityService {
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IUserClaimsPrincipalFactory<ApplicationUser> _userClaimsPrincipalFactory;
    private readonly IAuthorizationService _authorizationService;

    public IdentityService (
            UserManager<ApplicationUser> userManager,
            IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory,
            IAuthorizationService authorizationService
            ) {

        _userManager = userManager;
        _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
        _authorizationService = authorizationService;
    }

    public async Task<(Result Result, string UserId)> CreateUserAsync(CreateUserDto createUserDto) {
        var user = new ApplicationUser {
            UserName = createUserDto.userName,
            Email = createUserDto.email,
            FirstName = createUserDto.firstName,
            LastName = createUserDto.lastName,
            PhoneNumber = createUserDto.phoneNumber,
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            Bio = "This is a bio"
        };

        var result = await _userManager.CreateAsync(user, createUserDto.password);

        if (result.Succeeded) {
            return (Result.SuccessResult("Created User Successfully"), user.Id);
        }
        return (Result.FailureResult(result.Errors.Select(e => e.Description)), user.Id);
    }

    public async Task<Result> DeleteUserAsync(Guid userId) {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId.ToString());

        if (user == null) {
            return Result.FailureResult(new List<string> { "User does not exist" });
        }

        var result = await _userManager.DeleteAsync(user);

        if (result.Succeeded) {
            return Result.SuccessResult("Deleted User Successfully");
        }

        return Result.FailureResult(result.Errors.Select(e => e.Description));
    }

    public async Task<Result> UpdateUserAsync(UpdateUserDto updateUserDto) {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == updateUserDto.userId.ToString());

        if (user == null) {
            return Result.FailureResult(new List<string> { "User does not exist" });
        }

        user.UserName = updateUserDto.userName;
        user.Email = updateUserDto.email;
        user.FirstName = updateUserDto.firstName;
        user.LastName = updateUserDto.lastName;
        user.PhoneNumber = updateUserDto.phoneNumber;

        var result = await _userManager.UpdateAsync(user);

        if (result.Succeeded) {
            return Result.SuccessResult("Updated User Successfully");
        }

        return Result.FailureResult(result.Errors.Select(e => e.Description));
    }

    public async Task<bool> AuthorizeAsync(Guid userId, string policyName) {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId.ToString());

        if (user == null) {
            return false;
        }

        var userClaimsPrincipal = await _userClaimsPrincipalFactory.CreateAsync(user);
        var result = await _authorizationService.AuthorizeAsync(userClaimsPrincipal, policyName);

        return result.Succeeded;
    }

    public async Task<bool> IsInRoleAsync(Guid userId, string role) {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId.ToString());

        return user != null && await _userManager.IsInRoleAsync(user, role);
    }

}
        
