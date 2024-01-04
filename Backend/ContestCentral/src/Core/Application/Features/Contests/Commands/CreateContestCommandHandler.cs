using Application.Common.Models;
using Application.Interfaces;
using AutoMapper;
using Domain.Entity;
using MediatR;

namespace Application.Features.Contests.Commands;

public class CreateContestCommandHandler : IRequestHandler<CreateContestCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateContestCommandHandler( IUnitOfWork unitOfWork, IMapper mapper )
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<Result> Handle( CreateContestCommand request, CancellationToken cancellationToken)
    {
        var validatorResult = await new CreateContestCommandValidator().ValidateAsync(request, cancellationToken);

        if (!validatorResult.IsValid)
        {
            return Result.FailureResult(validatorResult.Errors.Select(e => e.ErrorMessage));
        }

        var contest = _mapper.Map<Contest>(request.CreateContest);

        await _unitOfWork.ContestRepository.AddAsync(contest);

        await _unitOfWork.CommitAsync();

        return Result.SuccessResult("Contest created successfully");
    }
}