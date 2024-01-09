using MediatR;

using Application.Common.Models;
using Application.Interfaces;

namespace Application.Features.Auth.Commands.Handler;

public class UpdateUserRoleCommandHandler : IRequestHandler<UpdateUserRoleCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUserRoleCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateUserRoleCommand request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.UserRepository.GetByIdAsync(request.Id);

        if (user == null)
        {
            return Result.FailureResult(new List<string> { "User not found" });
        }

        user.Role = request.NewRole;

        await _unitOfWork.UserRepository.UpdateAsync(user);
        await _unitOfWork.CommitAsync();

        return Result.SuccessResult("User role updated successfully");
    }
}
