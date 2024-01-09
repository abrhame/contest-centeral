using FluentValidation;

namespace Application.Features.Auth.Commands.Validator;

public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        // Rule For UserName. 
        RuleFor(u => u.Request.UserName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .Length(min:5, max:20).WithMessage("{PropertyName} must be between 5 and 20 characters.")
            .Matches("^[a-zA-Z0-9_]+$").WithMessage("{PropertyName} must contain only alphanumeric characters and underscores.");
        
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

        
        // Rule For FirstName.
        RuleFor(u => u.Request.FirstName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .Length(min:2, max:20).WithMessage("{PropertyName} must be between 2 and 20 characters.")
            .Matches("^[a-zA-Z0-9_]+$").WithMessage("{PropertyName} must contain only alphanumeric characters and underscores.");
        
        // Rule For LastName.
        RuleFor(u => u.Request.LastName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .Length(min:2, max:20).WithMessage("{PropertyName} must be between 2 and 20 characters.")
            .Matches("^[a-zA-Z0-9_]+$").WithMessage("{PropertyName} must contain only alphanumeric characters and underscores.");
        
    }
}
