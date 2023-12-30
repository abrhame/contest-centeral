namespace ContestCentral.Application.Common.DTOs;

public record AuthResponseDto(string Token, string RefreshToken, DateTime ExpiresIn, UserDto user);
