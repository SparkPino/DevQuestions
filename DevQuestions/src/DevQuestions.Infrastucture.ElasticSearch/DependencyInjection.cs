using DevQuestions.Application.FullTextSearch;
using DevQuestions.Application.Questions;
using DevQuestions.Infrastucture.ElasticSearch;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace DevQuestions.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastuctureElasticSearch(this IServiceCollection services)
    {
        services.AddScoped<ISearchProvider, ElasticSearchProvider>();
        return services;
    }
}