using DevQuestions.Application;
using DevQuestions.Application.Questions;
using DevQuestions.Infrastructure.PostgreSql.Repositories;
using DevQuestions.Infrastructure.PostgreSql.Seeders;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace DevQuestions.Infrastructure.PostgreSql;

public static class DependencyInjection
{
    public static IServiceCollection AddPostgreSqlInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IQuestionsRepository, QuestionsSqlRepository>();
        services.AddScoped<ISqlConnectionFactory, SqlConnectionFactory>();
        services.AddDbContext<QuestionDbContext>();

        return services;
    }
}