using Application.DTOs;
using MediatR;

namespace Application.Features.Submission.Commands.CreateSubmission
{
    public class CreateSubmissionCommand : IRequest<SubmissionDTO>
    {
        public string? QuestionId { get; set; }
        public int Trial { get; set; }
        public int Points { get; set; }
        public Guid? TeamId { get; set; }
        public Guid? UserId { get; set; }
        public Guid ContestId { get; set; }
    }
}
