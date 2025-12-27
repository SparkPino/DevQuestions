using Dapper;
using DevQuestions.Application.Questions;
using DevQuestions.Domain.Questions;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace DevQuestions.Infrastructure.PostgreSql.Repositories;

public class QuestionsSqlRepository
    (ISqlConnectionFactory sqlConnectionFactory) : IQuestionsRepository
{
    public async Task<Guid> AddAsync(Question question, CancellationToken cancellationToken)
    {
        const string sql = $"""
                            INSERT INTO questions (id, title, text, user_id, screenshot_id, tags, status) 
                            VALUES (@Id, @Title, @Text, @UserId, @ScreenshotId, @Tags, @Status)
                            """;
        using var connection = sqlConnectionFactory.Create();
        await connection.ExecuteAsync(sql, new
        {
            Id = question.Id,
            Title = question.Tittle,
            Text = question.Text,
            UserId = question.UserId,
            ScreenshotId = question.ScreenShotId,
            Tags = question.Tags.ToList(),
            Status = question.Status,
        });
        return question.Id;
    }

    public async Task<Guid> SaveAsync(Question question, CancellationToken cancellationToken)
    {
        return Guid.NewGuid();
    }

    public async Task<Guid> DeleteAsync(Guid questionId, CancellationToken cancellationToken)
    {
        return Guid.NewGuid();
    }

    public async Task<Question?> GetByIdAsync(Guid questionId, CancellationToken cancellationToken)
    {
        return new Question(Guid.NewGuid(), "bla", "blabla", Guid.NewGuid(), null, new List<Guid>());
    }

    public async Task<int> GetOpenUserQuestionsAsync(Guid userId, CancellationToken cancellationToken)
    {
        return 12;
    }
}