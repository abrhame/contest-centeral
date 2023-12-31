namespace ContestCentral.Application.Common.DTOs;

public record ResetPasswordRequestDto(string newPassword, string confirmPassword);
