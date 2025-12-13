using DevQuestions.Application.Questions;
using DevQuestions.Contracts.Questions;
using DevQuestions.Domain.Questions;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace DevQuestions.Application;

public class QuestionsService // сервисы нужно называть во множественном числе как и контроллеры
(
    IQuestionsRepository questionsRepository,
    ILogger<QuestionsService> logger,
    IValidator<CreateQuestionDto> validator) : IQuestionsService
{
    private readonly IQuestionsRepository _questionsRepository = questionsRepository;
    private readonly IValidator<CreateQuestionDto> _validator = validator;
    private readonly ILogger<QuestionsService> _logger = logger;

    public async Task<Guid> Create(CreateQuestionDto request, CancellationToken cancellationToken)
    {
        // Валидация входных даных
        var validatorResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validatorResult.IsValid)
        {
            throw new ValidationException(validatorResult.Errors);
        }

        // Валидация бизнес логики
        int openUserQuestionCount = await _questionsRepository
            .GetOpenUserQuestionsAsync(request.UserId, cancellationToken);
        if (openUserQuestionCount > 3)
        {
            throw new Exception("User has already 3 open questions");
        }

        var questionId = Guid.NewGuid();
        var question = new Question(
            questionId,
            request.Tittle,
            request.Text,
            request.UserId,
            null,
            request.TagsIds);


        await _questionsRepository.AddAsync(question, cancellationToken);

        _logger.LogInformation("Question created with id {QuestionId}", questionId);

        return questionId;
    }

    public async Task Update(
        Guid questionId,
        UpdateQuestionDto request,
        CancellationToken cancellationToken)
    {
    }

    public async Task Delete(Guid questionId, CancellationToken cancellationToken)
    {
    }

    public async Task SelectSolution(
        Guid questionId,
        Guid answerId,
        CancellationToken cancellationToken)
    {
    }

    public async Task AddAnswer(
        Guid questionId,
        AddAnswerDto request,
        CancellationToken cancellationToken)
    {
    }
}