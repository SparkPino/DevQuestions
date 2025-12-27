using DevQuestions.Domain.Questions;
using Microsoft.EntityFrameworkCore;

namespace DevQuestions.Infrastructure.PostgreSql;

public class QuestionDbContext : DbContext
{
    public DbSet<Question> Questions { get; set; }
}