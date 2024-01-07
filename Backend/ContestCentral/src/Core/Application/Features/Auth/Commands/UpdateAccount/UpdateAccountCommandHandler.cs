using MediatR;
using AutoMapper;

using Application.Common.Models;
using Application.Interfaces;
using Domain.Entity;

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
        var user = await _unitOfWork.UserRepository.GetByIdAsync(request.Id);

        if (user == null)
        {
            return Result.FailureResult(new List<string> { "User not found" });
        }

        var userUpdate = _mapper.Map<User>(request.UpdateUserRequestDto);

        user.FirstName = userUpdate.FirstName ?? user.FirstName;
        user.LastName = userUpdate.LastName ?? user.LastName;
        user.Email = userUpdate.Email ?? user.Email;
        user.UserName = userUpdate.UserName ?? user.UserName;
        user.PhoneNumber = userUpdate.PhoneNumber ?? user.PhoneNumber;
        user.Bio = userUpdate.Bio ?? user.Bio;
        user.Avatar = userUpdate.Avatar ?? user.Avatar;

        await _unitOfWork.UserRepository.UpdateAsync(user);
        await _unitOfWork.CommitAsync();

        return Result.SuccessResult("User updated successfully");
    }
}
