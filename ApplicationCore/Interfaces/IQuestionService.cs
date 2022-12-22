using Guliver_Backend_Assignment.Domain;
using Guliver_Backend_Assignment.ApplicationCore.DTOs;

namespace Guliver_Backend_Assignment.ApplicationCore.Interfaces
{
    public interface IQuestionService
    {
        Task<Question> GetAsync(int questionId);
        Task<Question> InsertQuestionAsync(QuestionDto newQuestion);
        Task<CollectedAnswer> VoteAnswerAsync(int questionId, int votedAnswerId);
        Task<int> GetNumberOfVotesPerAnswer(int questionId, int votedAnswerId);
    }
}