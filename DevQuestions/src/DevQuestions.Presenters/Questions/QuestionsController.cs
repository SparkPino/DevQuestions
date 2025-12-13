using DevQuestions.Application;
using DevQuestions.Contracts;
using DevQuestions.Contracts.Questions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DevQuestions.Presenters;

[ApiController]
[Route("[controller]")]
public class QuestionsController : ControllerBase
{
    private readonly IQuestionsService _questionsService;

    public QuestionsController(IQuestionsService questionsService)
    {
        _questionsService = questionsService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateQuestionDto request, CancellationToken cancellationToken)
    {
        var questionId=await _questionsService.Create(request, cancellationToken);
        return Ok(questionId);
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetQuestionsDto request, CancellationToken cancellationToken)

    // FromQuery параметры обозначаються после знака вопроса GET/questions?tag_id=1&page=1&limit=10&tite="test"
    {
        return Ok("Question get");
    }

    [HttpGet("{questionId:guid}")] // Когда мы указываем {questionId:guid}" он трансформируеться в GET/questions/{question_id} и questionId в передаваемом параметре в методе смапиться с этим
    public async Task<IActionResult> GetById([FromRoute] Guid questionId, CancellationToken cancellationToken)

    // [FromRout] указываеться после  GET/questions/{question_id}  "id" <- вот это route 
    {
        return Ok("Question get");
    }

    [HttpPut]
    public async Task<IActionResult> Update(
            [FromRoute] Guid questionId,
            [FromBody] UpdateQuestionDto request,
            CancellationToken cancellationToken)

        // Put /questions/{question_id} <- route, body-> {title: "update tittle}
    {
        return Ok("Question updated");
    }

    [HttpDelete("{questionId:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid questionId, CancellationToken cancellationToken)
    {
        return Ok("Question delete");
    }


    [HttpPut("{questionId:guid}/solution")]
    public async Task<IActionResult> SelectSolution(
        [FromRoute] Guid questionId,
        [FromQuery] Guid answerId,
        CancellationToken cancellationToken)
    {
        return Ok("Solution selected");
    }

    [HttpPost("{questionId:guid}/answers")]
    public async Task<IActionResult> AddAnswer(
        [FromRoute] Guid questionId,
        [FromBody] AddAnswerDto request,
        CancellationToken cancellationToken)
    {
        return Ok("Answer added");
    }
}