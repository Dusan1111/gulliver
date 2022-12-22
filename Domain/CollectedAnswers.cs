
namespace Guliver_Backend_Assignment.Domain;
public class CollectedAnswer
{
    public int Id { get; private set; }
    public int QuestionId { get; private set; }
    public Question Question { get; private set; }
    public Answer Answer { get; private set; }
    public int AnswerId { get; private set; }

    public CollectedAnswer() { }
    public CollectedAnswer(int questionId, int answerId)
    {
        if (questionId == default)
        {
            throw new ArgumentNullException("Question must be defined!");
        }
        if (answerId == default)
        {
            throw new ArgumentNullException("Answer must be defined!");
        }

        this.QuestionId = questionId;
        this.AnswerId = answerId;
    }
}