using Application.Interfaces;
using AutoMapper;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class QuestionRepository : IQuestionRepository
{
    private readonly ContestCentralDbContext _dbContext;
    private IMapper _mapper;

    public QuestionRepository(ContestCentralDbContext dbContext,IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public async Task<Question> AddQuestion(Question question)
    {
        
        var existingQuestion = await _dbContext.Questions.FirstOrDefaultAsync(q => q.Title == question.Title);
        if (existingQuestion == null)
        {
            var newQuestion = new Question
            {
                Title = question.Title,
                AskedCount = 1,  
                Rating = question.Rating
            };

            // Add the new question to the database
            _dbContext.Questions.Add(newQuestion);
            await _dbContext.SaveChangesAsync();
            return newQuestion;   

        }
        else
        {
            var newQuestion = new Question
            {
                Title = question.Title,
                AskedCount = existingQuestion.AskedCount++,  
                Rating = question.Rating
            };
            _dbContext.Questions.Add(newQuestion);
            await _dbContext.SaveChangesAsync();

            return newQuestion;
        }

    }

    public async Task<Question> GetQuestionByTitle(string title)
    {
         var question = await _dbContext.Questions
            .FirstOrDefaultAsync(q => q.Title == title);

        return question;
    }
    
    public async Task<int> GetAskedAmount(string title)
    {
        var askedCount = await _dbContext.Questions
        .Where(q => q.Title == title)
        .Select(q => q.AskedCount)
        .FirstOrDefaultAsync();

    
        return askedCount > 0 ? askedCount : 0;
    }
}