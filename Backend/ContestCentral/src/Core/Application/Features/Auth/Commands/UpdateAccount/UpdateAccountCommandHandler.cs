using MediatR;
using AutoMapper;

using Application.Common.Models;
using Application.Interfaces;
using Domain.Entity;

using Application.Features.Auth.Commands.Validator;

namespace Application.Features.Auth.Commands.Handler;

public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateAccountCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
    {

        var validationResult = await new UpdateAccountCommandValidator().ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            return Result.FailureResult(validationResult.Errors.Select(e => e.ErrorMessage));
        }

        var user = await _unitOfWork.UserRepository.GetByIdAsync(request.Id);

        if (user == null)
        {
            return Result.FailureResult(new List<string> { "User not found" });
        }

        var userUpdate = _mapper.Map<User>(request.UpdateUserRequestDto);

        user.FirstName = userUpdate.FirstName;
        user.LastName = userUpdate.LastName;
        user.Email = userUpdate.Email;
        user.UserName = userUpdate.UserName;
        user.PhoneNumber = userUpdate.PhoneNumber;
        user.Bio = userUpdate.Bio;
        user.Avatar = userUpdate.Avatar;

        await _unitOfWork.UserRepository.UpdateAsync(user);
        await _unitOfWork.CommitAsync();

        return Result.SuccessResult("User updated successfully");
    }
}
