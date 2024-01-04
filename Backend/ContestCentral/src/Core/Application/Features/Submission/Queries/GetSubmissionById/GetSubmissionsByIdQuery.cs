using System;
using MediatR;
using Application.DTOs;

namespace Application.Features.Submission.Queries.GetSubmissionById
{
    public class GetSubmissionByIdQuery : IRequest<SubmissionDTO>
    {
        public Guid SubmissionId { get; set; }

        public GetSubmissionByIdQuery(Guid submissionId)
        {
            SubmissionId = submissionId;
        }
    }
}
