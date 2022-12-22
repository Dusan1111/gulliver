using Guliver_Backend_Assignment.ApplicationCore.Interfaces;
using Guliver_Backend_Assignment.Domain;
using Microsoft.EntityFrameworkCore;

namespace Guliver_Backend_Assignment.Infrastructure;


public class QuestionRepository : IQuestionRepository
{
    private readonly ApplicationDbContext context;
    public QuestionRepository(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<Question> InsertAsync(Question newQuestion)
    {

        foreach (var answer in newQuestion.Answers)
        {
            context.Answers.Add(answer);
        }
        context.Questions.Add(newQuestion);
        await context.SaveChangesAsync();

        return newQuestion;
    }

    public async Task<Question> GetAsync(int questionId)
    {
        return await context.Questions
                                .Include(x => x.Answers)
                                .FirstOrDefaultAsync(question => question.Id == questionId);
    }

    public async Task<CollectedAnswer> VoteAnswerAsync(CollectedAnswer collectedAnswer)
    {
        context.CollectedAnswers.Add(collectedAnswer);
        await context.SaveChangesAsync();

        return collectedAnswer;
    }

    public async Task<int> GetNumberOfVotesPerAnswer(int questionId, int votedAnswerId)
    {
        return await context.CollectedAnswers.CountAsync(x => x.Question.Id == questionId && x.Answer.Id == votedAnswerId);
    }
    public async Task<Answer> GetAnswerAsync(int answerId)
    {
        return await context.Answers.FirstOrDefaultAsync(answer => answer.Id == answerId);
    }
}
