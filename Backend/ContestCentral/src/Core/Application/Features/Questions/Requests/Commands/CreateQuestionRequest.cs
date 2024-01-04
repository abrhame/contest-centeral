using Application.DTOs;
using Domain.Entity;
using MediatR;

namespace Application.Features.Questions.Requests;

public class CreateQuestionRequest : IRequest<GetQuestionByTitleDto>
{
    public string Title { get; set; }
    public int Rating { get; set; }
    // public ICollection<Tags> Tags { get; set; } = new List<Tags>();
}
