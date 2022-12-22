using Guliver_Backend_Assignment.ApplicationCore.Interfaces;
using Guliver_Backend_Assignment.ApplicationCore.DTOs;

using Guliver_Backend_Assignment.Domain;

namespace Guliver_Backend_Assignment.ApplicationCore;

public class QuestionService : IQuestionService
{
    private readonly IQuestionRepository questionRepository;
    public QuestionService(IQuestionRepository questionRepository)
    {
        this.questionRepository = questionRepository;
    }

    public Task<Question> InsertQuestionAsync(QuestionDto newQuestionDto)
    {
        List<Answer> answerList = new List<Answer>(8);

        foreach (var answer in newQuestionDto.Answers)
        {
            Answer answerModel = new Answer(answer.Text, answer.IsCorrect);
            answerList.Add(answerModel);
        }

        Question newQuestion = new Question(newQuestionDto.Text, answerList);

        return this.questionRepository.InsertAsync(newQuestion);
    }

    public async Task<Question> GetAsync(int questionId)
    {
        if (questionId == default)
        {
            throw new ArgumentException("There is no question with id 0!");
        }
        return await this.questionRepository.GetAsync(questionId);
    }

    public async Task<CollectedAnswer> VoteAnswerAsync(int questionId, int votedAnswerId)
    {
        if (questionId == default)
        {
            throw new ArgumentException("There is no question with id 0!");
        }
        if (votedAnswerId == default)
        {
            throw new ArgumentException("There is no answer with id 0!");
        }
        Question question = await GetAsync(questionId);

        if (question is null)
        {
            throw new ArgumentException($"Question with id: '{questionId}' not found!");
        }

        Answer answerModel = await this.questionRepository.GetAnswerAsync(votedAnswerId);

        if (answerModel is null)
        {
            throw new ArgumentException($"Answer with id: '{votedAnswerId}' not found!");
        }

        if (!question.Answers.Any(x => x.Id == votedAnswerId))
        {
            throw new ArgumentException($"Answer with id: '{votedAnswerId}' is not defined for question: '{question.Text}'!");
        }

        CollectedAnswer collectedAnswer = new CollectedAnswer(questionId, votedAnswerId);
        return await this.questionRepository.VoteAnswerAsync(collectedAnswer);
    }

    public async Task<int> GetNumberOfVotesPerAnswer(int questionId, int votedAnswerId)
    {
        return await this.questionRepository.GetNumberOfVotesPerAnswer(questionId, votedAnswerId);
    }
}


