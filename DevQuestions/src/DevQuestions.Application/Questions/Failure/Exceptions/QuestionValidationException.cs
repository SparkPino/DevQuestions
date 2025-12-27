using DevQuestions.Application.Exceptions;
using Shared;

namespace DevQuestions.Application.Questions.Failure.Exceptions;

public class QuestionValidationException : BadRequestException
{
    public QuestionValidationException(Error[] errors)
        : base(errors)
    {
    }

}