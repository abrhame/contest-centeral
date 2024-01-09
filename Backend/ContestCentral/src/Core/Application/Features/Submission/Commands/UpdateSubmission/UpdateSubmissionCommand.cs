using Application.DTOs;
using MediatR;

namespace Application.Features.Submission.Commands.UpdateSubmission
{
    public class UpdateSubmissionCommand : IRequest<SubmissionDTO>
    {
        public Guid SubmissionId { get; set; }
        public int UpdatedTrial { get; set; }
        public int UpdatedPoints { get; set; }
    }
}
