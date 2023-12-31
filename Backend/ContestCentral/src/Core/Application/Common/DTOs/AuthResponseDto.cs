namespace ContestCentral.Application.Common.DTOs;

public record AuthResponseDto(string accessToken, UserDto user, string refreshToken);
