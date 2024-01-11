using Domain.Constant;

namespace Application.DTOs;

public record UserDto (
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string UserName,
    Role Role
);
