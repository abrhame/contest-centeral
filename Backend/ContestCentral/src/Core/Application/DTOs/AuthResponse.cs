namespace Application.DTOs;

public record AuthResponseDto(string accessToken, UserDto user, string refreshToken);
