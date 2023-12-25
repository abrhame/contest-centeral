namespace ContestCentral.Application.Common.DTOs;

public record LoginUserRequestDto {
    public required string Email; 
    public required string Password;
};
