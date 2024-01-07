using FluentValidation;

namespace Application.Features.Groups.UpdateGroup.Validator;

public class UpdateGroupCommandValidator : AbstractValidator<UpdateGroupCommand>
{
    public UpdateGroupCommandValidator()
    {
    }
}
