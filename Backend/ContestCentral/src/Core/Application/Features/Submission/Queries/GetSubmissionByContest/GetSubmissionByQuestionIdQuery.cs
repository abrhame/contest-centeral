using System;
using MediatR;
using Application.DTOs;

namespace Application.Features.Submission.Queries.GetSubmissionByContest
{
    public class GetSubmissionsByContestIdQuery : IRequest<IEnumerable<SubmissionDTO>>
    {
        public Guid ContestId { get; set; }

        public GetSubmissionsByContestIdQuery(Guid contestId)
        {
            ContestId = contestId;
        }
    }
}
