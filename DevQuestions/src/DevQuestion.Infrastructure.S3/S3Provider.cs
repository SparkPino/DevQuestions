using DevQuestions.Application.FilesStorage;

namespace DevQuestion.Infrastructure.S3;

public class S3Provider : IFilesProvider
{
    public Task<string> UpLoadAsync(Stream stream, string key, string bucket) => throw new NotImplementedException();
}