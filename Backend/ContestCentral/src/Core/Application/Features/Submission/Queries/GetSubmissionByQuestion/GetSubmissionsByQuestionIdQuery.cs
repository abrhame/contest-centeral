using MediatR;
using Application.DTOs;

namespace Application.Features.Submission.Queries.GetSubmissionByQuestion
{
    public class GetSubmissionsByQuestionIdQuery : IRequest<IEnumerable<SubmissionDTO>>
    {
        public string QuestionId { get; set; }

        public GetSubmissionsByQuestionIdQuery(string questionId)
        {
            QuestionId = questionId ?? throw new ArgumentNullException(nameof(questionId));
        }
    }
}
