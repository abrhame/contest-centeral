using FluentValidation;

namespace Application.Features.Auth.Commands.Validator;

public class UpdateAccountCommandValidator : AbstractValidator<UpdateAccountCommand>
{
    public UpdateAccountCommandValidator()
    {
        // Rule For UserName. 
        RuleFor(u => u.UpdateUserRequestDto.UserName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .Length(min:5, max:20).WithMessage("{PropertyName} must be between 5 and 20 characters.")
            .Matches("^[a-zA-Z0-9_]+$").WithMessage("{PropertyName} must contain only alphanumeric characters and underscores.");
        
        // Rule For Email.
        RuleFor(u => u.UpdateUserRequestDto.Email)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .EmailAddress().WithMessage("{PropertyName} is not a valid email address.");
        
        // Rule For FirstName.
        RuleFor(u => u.UpdateUserRequestDto.FirstName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .Length(min:2, max:20).WithMessage("{PropertyName} must be between 2 and 20 characters.")
            .Matches("^[a-zA-Z0-9_]+$").WithMessage("{PropertyName} must contain only alphanumeric characters and underscores.");
        
        // Rule For LastName.
        RuleFor(u => u.UpdateUserRequestDto.LastName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .Length(min:2, max:20).WithMessage("{PropertyName} must be between 2 and 20 characters.")
            .Matches("^[a-zA-Z0-9_]+$").WithMessage("{PropertyName} must contain only alphanumeric characters and underscores.");

        // Rule For Bio.
        RuleFor(u => u.UpdateUserRequestDto.Bio)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .Length(min:2, max:100).WithMessage("{PropertyName} must be between 2 and 100 characters.");

        // Rule For Avatar.
        RuleFor(u => u.UpdateUserRequestDto.Avatar)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .Length(min:2, max:100).WithMessage("{PropertyName} must be between 2 and 100 characters.");
    }
}
