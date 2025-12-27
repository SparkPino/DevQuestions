using Shared;

namespace DevQuestions.Application.Questions.Failure;

public partial class Errors
{
    public static class Question
    {
        public static Error ToManyQuestions() =>
            Error.Failure("questions.to.many", "Пользователь не может открыть более 3 вопросов");

        public static Error QuestionValidationException() =>
            Error.Validation("questions.not.found", "Вопрос не найден", null);
    }
}