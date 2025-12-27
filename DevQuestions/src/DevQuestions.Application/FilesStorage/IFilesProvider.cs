namespace DevQuestions.Application.FilesStorage;

public interface IFilesProvider
{
    Task<string> UpLoadAsync(Stream stream, string key, string bucket);
}