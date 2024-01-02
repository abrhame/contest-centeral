using FluentValidation;

namespace Application.Features.Auth.Commands.Validator;

public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
{
    public LoginUserCommandValidator()
    {
        // Rule For Email.
        RuleFor(u => u.Request.Email)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .EmailAddress().WithMessage("{PropertyName} is not a valid email address.");
        
        // Rule For Password.
        RuleFor(u => u.Request.Password)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MinimumLength(8).WithMessage("{PropertyName} must be at least 8 characters.")
            .Matches("[A-Z]").WithMessage("{PropertyName} must contain at least 1 uppercase letter.")
            .Matches("[a-z]").WithMessage("{PropertyName} must contain at least 1 lowercase letter.")
            .Matches("[0-9]").WithMessage("{PropertyName} must contain at least 1 number.")
            .Matches("[^a-zA-Z0-9]").WithMessage("{PropertyName} must contain at least 1 non-alphanumeric character.");
    }
}
