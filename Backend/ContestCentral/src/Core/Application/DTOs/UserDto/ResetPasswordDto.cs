namespace Application.DTOs;

public record ResetPasswordRequestDto(string newPassword, string confirmPassword);
