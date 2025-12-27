using DevQuestions.Application.Exceptions;


namespace DevQuestions.Application.Questions.Failure.Exceptions;

public class ToManyQuestionsException : BadRequestException
{
    public ToManyQuestionsException()
        : base([Errors.Question.ToManyQuestions()])
    {
    }
}