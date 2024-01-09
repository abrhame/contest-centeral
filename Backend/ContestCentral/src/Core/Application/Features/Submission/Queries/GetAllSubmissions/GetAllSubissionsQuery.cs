using System.Collections.Generic;
using Application.DTOs;
using MediatR;

namespace Application.Features.Submission.Queries.GetAllSubmissions
{
    public class GetAllSubmissionsQuery : IRequest<IEnumerable<SubmissionDTO>>
    {
    }
}
