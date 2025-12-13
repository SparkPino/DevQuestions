namespace DevQuestions.Contracts.Questions;

public record CreateQuestionDto(string Tittle, string Text, Guid UserId, Guid[] TagsIds);