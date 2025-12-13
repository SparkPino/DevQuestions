using DevQuestions.Contracts.Questions;
using FluentValidation;

namespace DevQuestions.Application.Questions;

public class CreatedQuestionValidator : AbstractValidator<CreateQuestionDto>
{
    public CreatedQuestionValidator()
    {
        RuleFor(x => x.Tittle).NotEmpty().WithMessage("Title cat`t be empty").MaximumLength(500).WithMessage("Title must be between 1 and 500 characters");

        RuleFor(x=>x.Text).NotEmpty().WithMessage("Text cat`t be empty").MaximumLength(5000).WithMessage("Text must be between 1 and 5000 characters");

        RuleFor(x=>x.UserId).NotEmpty().WithMessage("UserId cat`t be empty");

        // ChildRules для внутренних валидаций внутри каждого обьекта в колекции
        RuleForEach(x => x.TagsIds).NotEmpty();
    }
}