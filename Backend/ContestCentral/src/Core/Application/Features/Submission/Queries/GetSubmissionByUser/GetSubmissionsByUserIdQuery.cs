using MediatR;
using Application.DTOs;

namespace Application.Features.Submission.Queries.GetSubmissionByUser
{
    public class GetSubmissionsByUserIdQuery : IRequest<IEnumerable<SubmissionDTO>>
    {
        public Guid UserId { get; set; }

        public GetSubmissionsByUserIdQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}