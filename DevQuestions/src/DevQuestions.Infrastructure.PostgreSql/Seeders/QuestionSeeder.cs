namespace DevQuestions.Infrastructure.PostgreSql.Seeders;

public class QuestionSeeder : ISeeder
{
    private readonly QuestionDbContext _questionDbContext;

    public QuestionSeeder(QuestionDbContext questionDbContext)
    {
        _questionDbContext = questionDbContext;
    }

    public Task SeedAsync()
    {
     throw new NotImplementedException();
    }
}