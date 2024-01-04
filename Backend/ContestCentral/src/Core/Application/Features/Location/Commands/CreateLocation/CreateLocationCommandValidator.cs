using FluentValidation;

namespace Application.Features.Locations.Commands.Validator;

public class CreateLocationCommandValidator : AbstractValidator<CreateLocationCommand>
{
    public CreateLocationCommandValidator()
    {
        RuleFor(u => u.request.City)
            .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(u => u.request.Country)
            .NotEmpty().WithMessage("{PropertyName} is required.");

    }
}
