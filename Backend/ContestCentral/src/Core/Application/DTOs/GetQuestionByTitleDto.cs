using Domain.Entity;

namespace Application.DTOs;

public class GetQuestionByTitleDto
{
    public string Title { get; set; } = string.Empty;
    public int Rating { get; set; }

    public ICollection<Tags> Tags { get; set; } = new List<Tags>();
    public int AskedCount{get; set;}
}