using FluentValidation;

namespace Application.Features.Contests.Commands;

public class CreateContestCommandValidator : AbstractValidator<CreateContestCommand>
{
    public CreateContestCommandValidator()
    {
        RuleFor(v => v.CreateContest.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(200).WithMessage("Name must not exceed 200 characters.");

        RuleFor(v => v.CreateContest.ContestStatus)
            .NotEmpty().WithMessage("ContestStatus is required.");
        
        RuleFor(v => v.CreateContest.ContestType)
            .NotEmpty().WithMessage("Contest Type is required.");
        RuleFor(v => v.CreateContest.ContestUrl)
            .NotEmpty().WithMessage("Contest Url is required.")
            .MaximumLength(200).WithMessage("Contest Url must not exceed 200 characters.");
        RuleFor(v => v.CreateContest.ContestDate)
            .NotEmpty().WithMessage("Contest Date is required.");
        RuleFor(v => v.CreateContest.CreatorName)
            .NotEmpty().WithMessage("Creator Name is required.");
        RuleFor(v => v.CreateContest.Duration)
            .NotEmpty().WithMessage("Duration is required.");
        
    }
    
}