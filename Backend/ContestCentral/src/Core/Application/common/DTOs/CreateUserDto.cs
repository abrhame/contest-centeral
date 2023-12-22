namespace ContestCentral.Application.Common.DTOs; 

public record CreateUserDto (string userName, string email, string password, string firstName, string lastName, string phoneNumber);


