using DevQuestions.Contracts.Questions;

namespace DevQuestions.Application;

public interface IQuestionsService
{
    Task<Guid> Create(CreateQuestionDto request, CancellationToken cancellationToken);
}