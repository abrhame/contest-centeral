using FluentValidation;

namespace Application.Features.Groups.CreateGroup.Validator;

public class CreateGroupCommandValidator : AbstractValidator<CreateGroupCommand>
{
    public CreateGroupCommandValidator()
    {
        RuleFor(v => v.CreateGroup.GroupDto.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(200).WithMessage("Name must not exceed 200 characters.");

        RuleFor(v => v.CreateGroup.GroupDto.ShortName)
            .NotEmpty().WithMessage("ShortName is required.")
            .MaximumLength(200).WithMessage("ShortName must not exceed 200 characters.");

        RuleFor(v => v.CreateGroup.LocationCode)
            .NotEmpty().WithMessage("Location is required.")
            .MaximumLength(200).WithMessage("ShortName must not exceed 200 characters.");
    }
}
