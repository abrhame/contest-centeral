using ContestCentral.Application.Common.Models;
using ContestCentral.Application.Common.DTOs;

namespace ContestCentral.Application.Interfaces;

public interface IIdentityService {
    Task<bool> IsInRoleAsync(Guid userId, string role);
    Task<bool> AuthorizeAsync(Guid userId, string policyName);
    Task<(Result Result, string UserId)> CreateUserAsync(CreateUserDto createUserDto);
    Task<Result> UpdateUserAsync(UpdateUserDto updateUserDto);
    Task<Result> DeleteUserAsync(Guid userId);
}
