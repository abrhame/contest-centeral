namespace Application.DTOs;

public record AuthResponseDto(string AccessToken, UserDto User, string RefreshToken);
