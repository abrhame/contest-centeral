namespace Application.DTOs;

public record AuthResponseDto( string AccessToken, string RefreshToken, UserDto User );
