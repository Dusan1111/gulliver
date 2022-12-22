namespace Guliver_Backend_Assignment.Domain;

public class PollQuestion : Question
{
    public PollQuestion()
    {
        
    }   
    public PollQuestion(string text, IReadOnlyCollection<Answer> answers)
        :base(text, answers)
    {
        HasMultipleAnswers = false;
        HasCorrectAnswer = false;
    }
}
