namespace ContestCentral.Application.Common.DTOs;

public record RegisterUserRequestDto {
    public required string UserName; 
    public required string FirstName;
    public required string LastName;  
    public required string Email; 
    public required string Password;
};
