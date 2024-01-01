using Domain.Constant;

namespace Application.DTOs;

public record UserDto(
    string FirstName,
    string LastName,
    string Email,
    string UserName,
    Role Role
);
