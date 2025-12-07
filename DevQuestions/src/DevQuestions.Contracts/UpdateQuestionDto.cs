namespace DevQuestions.Contracts;

public record UpdateQuestionDto(string Tittle, string Body, Guid[] TagsIds);