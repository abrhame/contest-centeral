using Domain.Entity;

namespace Application.Interfaces;

public interface IQuestionRepository : IGenericRepository<Question>
{
    Task<Question> AddQuestion(Question question);
    Task<Question?> GetQuestionByTitle(string title);
    Task<int> GetAskedAmount(string Title);
}
