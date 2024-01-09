using FluentValidation;

namespace Application.Features.Locations.Commands.Validator;

public class UpdateLocationCommandValidator : AbstractValidator<UpdateLocationCommand>
{
    public UpdateLocationCommandValidator()
    {
    }
}
