using Application.DTOs;
using MediatR;

namespace Application.Features.Questions.Requests;

public class CreateQuestionRequest : IRequest<GetQuestionByTitleDto>
{
    public string Title { get; set; } = string.Empty;
    public int Rating { get; set; }
}
