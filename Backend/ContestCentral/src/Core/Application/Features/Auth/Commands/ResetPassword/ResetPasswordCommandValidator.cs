using FluentValidation;

namespace Application.Features.Auth.Commands.Validator;

public class ResetPasswordCommandValidator : AbstractValidator<ResetPasswordCommand>
{
    public ResetPasswordCommandValidator()
    {
        RuleFor(u => u.Request.newPassword)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MinimumLength(8).WithMessage("{PropertyName} must be at least 8 characters.")
            .Matches("[A-Z]").WithMessage("{PropertyName} must contain at least 1 uppercase letter.")
            .Matches("[a-z]").WithMessage("{PropertyName} must contain at least 1 lowercase letter.")
            .Matches("[0-9]").WithMessage("{PropertyName} must contain at least 1 number.")
            .Matches("[^a-zA-Z0-9]").WithMessage("{PropertyName} must contain at least 1 non-alphanumeric character.");

        RuleFor(u => u.Request.confirmPassword)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MinimumLength(8).WithMessage("{PropertyName} must be at least 8 characters.")
            .Matches("[A-Z]").WithMessage("{PropertyName} must contain at least 1 uppercase letter.")
            .Matches("[a-z]").WithMessage("{PropertyName} must contain at least 1 lowercase letter.")
            .Matches("[0-9]").WithMessage("{PropertyName} must contain at least 1 number.")
            .Matches("[^a-zA-Z0-9]").WithMessage("{PropertyName} must contain at least 1 non-alphanumeric character.");

        RuleFor(u => u.Request.newPassword)
            .Equal(u => u.Request.confirmPassword).WithMessage("Passwords do not match.");
    }
}
