using DevQuestions.Application.Exceptions;
using Shared;

namespace DevQuestions.Application.Questions.Failure.Exceptions;

public class QuestionNotFoundException: NotFoundException
{
    public QuestionNotFoundException(Error[] errors)
        : base(errors)
    {
    }
}