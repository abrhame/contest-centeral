using Application.DTOs;
using MediatR;

namespace Application.Features.Questions.Requests;

public class GetQuestionByTitleRequest : IRequest<GetQuestionByTitleDto>
{
    public string Title { get; set; } = string.Empty;
}
