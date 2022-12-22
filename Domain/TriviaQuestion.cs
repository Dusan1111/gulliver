namespace Guliver_Backend_Assignment.Domain;
public class TriviaQuestion : Question
{
    public TriviaQuestion()
    {
        
    }   
    public TriviaQuestion(string text, IReadOnlyCollection<Answer> answers)
        :base(text, answers)
    {
        HasCorrectAnswer = true;    
        HasMultipleAnswers = false;
        
    }

}