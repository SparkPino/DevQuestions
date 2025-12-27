namespace DevQuestions.Infrastucture.ElasticSearch;

using DevQuestions.Application.FullTextSearch;

public class ElasticSearchProvider : ISearchProvider
{
    public Task<List<Guid>> SearchAsync(string query, CancellationToken cancellationToken) => throw new NotImplementedException();

    public Task IndexQuestuionAsync(Guid question) => throw new NotImplementedException();
}