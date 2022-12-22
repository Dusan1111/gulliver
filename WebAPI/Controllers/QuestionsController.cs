using Guliver_Backend_Assignment.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Guliver_Backend_Assignment.Domain;
using Guliver_Backend_Assignment.WebAPI.DTOs;
using Guliver_Backend_Assignment.ApplicationCore.DTOs;

namespace Guliver_Backend_Assignment.Controllers;

[ApiController]
[Route("question")]
public class QuestionsController : ControllerBase
{
    private IQuestionService questionService;
    private IMapper mapper;

    public QuestionsController(IQuestionService questionService, IMapper mapper)
    {
        this.questionService = questionService;
        this.mapper = mapper;
    }

    /// <summary>
    /// Gets the question associated with the specified id
    /// </summary>
    /// <param name="id"> The uniqeue question id </param>
    /// <returns> Returns a question for the specified id</returns>
    [HttpGet("{questionId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(QuestionDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<QuestionDto>> GetQuestion(int questionId)
    {
        var question = await questionService.GetAsync(questionId);

        QuestionDto newQuestionDto = this.mapper.Map<Question, QuestionDto>(question);

        return newQuestionDto;
    }

    /// Adds new question
    /// </summary>
    /// <param name="newQuestion"> The question that is supposed to be added </param>
    /// <returns> </returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<int>> InsertQuestion(QuestionDto newQuestionDto)
    {
        var createdQuestion = await questionService.InsertQuestionAsync(newQuestionDto);

        return Created(createdQuestion.Id.ToString(), createdQuestion.Id);
    }

    /// <summary>
    /// Updates question with specified id
    /// </summary>
    /// <param name="id"> The uniqeue question id </param>
    /// <param name="questionForUpdate"> Question with updated data </param>
    /// <returns> </returns>
    [HttpPost("{questionId}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<VotedAnswerDto>> VoteAnswer(int questionId, [FromBody()] AnswerDto votedAnswerDto)
    {
        var collectedAnswer = await questionService.VoteAnswerAsync(questionId, votedAnswerDto.Id);

        int numberOfVotesPerAnswer = await questionService.GetNumberOfVotesPerAnswer(questionId, votedAnswerDto.Id);

        VotedAnswerDto? votedAnserDto = null;

        if (collectedAnswer.Question.QuestionType == QuestionType.Trivia)
        {
            votedAnserDto = new TriviaVotedAnswerDto(numberOfVotesPerAnswer, collectedAnswer.Answer.IsCorrect);
        }
        else if (collectedAnswer.Question.QuestionType == QuestionType.Poll)
        {
            votedAnserDto = new VotedAnswerDto(numberOfVotesPerAnswer);
        }

        return Ok(votedAnserDto);
    }
}
