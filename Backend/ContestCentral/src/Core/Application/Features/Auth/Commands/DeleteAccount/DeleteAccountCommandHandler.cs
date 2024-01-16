using MediatR;

using Application.Common.Models;
using Application.Interfaces;

namespace Application.Features.Auth.Commands.Handler;

public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAccountCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.UserRepository.GetByIdAsync(request.Id);

        if (user == null)
        {
            return Result.FailureResult(new List<string> { "User not found" });
        }

        await _unitOfWork.UserRepository.DeleteAsync(user);
        await _unitOfWork.CommitAsync();

        return Result.SuccessResult("User deleted successfully");
    }
}
