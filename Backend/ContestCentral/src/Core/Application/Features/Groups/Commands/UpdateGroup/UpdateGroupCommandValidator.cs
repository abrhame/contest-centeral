using FluentValidation;

namespace Application.Features.Groups.UpdateGroup.Validator;

public class UpdateGroupCommandValidator : AbstractValidator<UpdateGroupCommand>
{
    public UpdateGroupCommandValidator()
    {
        RuleFor(v => v.GroupDto.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(200).WithMessage("Name must not exceed 200 characters.");

        RuleFor(v => v.GroupDto.ShortName)
            .NotEmpty().WithMessage("ShortName is required.")
            .MaximumLength(200).WithMessage("ShortName must not exceed 200 characters.");
    }
}
