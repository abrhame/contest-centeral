using Domain.Constant;

namespace Application.DTOs;

public record UserResponseDto (
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string UserName,
    Role Role
);
