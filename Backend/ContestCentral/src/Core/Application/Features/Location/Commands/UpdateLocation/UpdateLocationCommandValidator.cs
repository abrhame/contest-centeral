using FluentValidation;

namespace Application.Features.Locations.Commands.Validator;

public class UpdateLocationCommandValidator : AbstractValidator<UpdateLocationCommand>
{
    public UpdateLocationCommandValidator()
    {
        RuleFor(u => u.requestDto.City)
            .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(u => u.requestDto.Country)
            .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(u => u.requestDto.ShortName)
            .NotEmpty().WithMessage("{PropertyName} is required.");
    }
}
