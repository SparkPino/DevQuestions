namespace DevQuestions.Contracts;

public record CreateQuestionDto(string Tittle, string Body, Guid UserId, Guid[] TagsIds);