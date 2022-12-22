using Guliver_Backend_Assignment.Domain;

namespace Guliver_Backend_Assignment.ApplicationCore.Interfaces
{
    public interface IQuestionRepository
    {
        Task<Question> GetAsync(int questionId);
        Task<Question> InsertAsync(Question newQuestion);
        Task<CollectedAnswer> VoteAnswerAsync(CollectedAnswer collectedAnswer);
        Task<int> GetNumberOfVotesPerAnswer(int questionId, int votedAnswerId);
        Task<Answer> GetAnswerAsync(int answerId);

    }
}