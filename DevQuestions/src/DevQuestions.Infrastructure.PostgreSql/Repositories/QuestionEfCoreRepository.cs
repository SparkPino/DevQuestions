using DevQuestions.Application.Questions;
using DevQuestions.Domain.Questions;
using Microsoft.EntityFrameworkCore;

namespace DevQuestions.Infrastructure.PostgreSql.Repositories;

public class QuestionEfCoreRepository
    (QuestionDbContext dbContext) : IQuestionsRepository
{
    public async Task<Guid> AddAsync(Question question, CancellationToken cancellationToken)
    {
       await dbContext.Questions.AddAsync(question, cancellationToken);

       await dbContext.SaveChangesAsync(cancellationToken);

       return question.Id;
    }

    public Task<Guid> SaveAsync(Question question, CancellationToken cancellationToken) => throw new NotImplementedException();

    public Task<Guid> DeleteAsync(Guid questionId, CancellationToken cancellationToken) => throw new NotImplementedException();

    public async Task<Question?> GetByIdAsync(Guid questionId, CancellationToken cancellationToken)
    {
        var questions = await dbContext.Questions
            .Include(a => a.Answers)
            .Include(a => a.Solution)
            .FirstOrDefaultAsync(a => a.Id == questionId, cancellationToken);
        return questions ?? null;
    }

    public Task<int> GetOpenUserQuestionsAsync(Guid userId, CancellationToken cancellationToken) => throw new NotImplementedException();
}