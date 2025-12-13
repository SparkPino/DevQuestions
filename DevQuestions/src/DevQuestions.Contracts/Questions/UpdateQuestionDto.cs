namespace DevQuestions.Contracts.Questions;

public record UpdateQuestionDto(string Tittle, string Body, Guid[] TagsIds);