using Domain.Constant;

namespace Application.DTOs;

public record CreateUserRequestDto {
    public string UserName { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty; 
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string GroupShortName { get; set; } = string.Empty;

    public Role Role { get; set; } = Role.Student;
    public StudentType StudentType { get; set; } = StudentType.Onsite;
};
