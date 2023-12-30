using ContestCentral.Domain.Constants;

namespace ContestCentral.Application.Common.DTOs;

public record UserDto(string FirstName, string LastName, String Email, Role Role, string UserName);
