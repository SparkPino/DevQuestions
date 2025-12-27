using System.Data;

namespace DevQuestions.Infrastructure.PostgreSql;

public interface ISqlConnectionFactory
{
    IDbConnection Create();
}