
namespace Guliver_Backend_Assignment.Domain;

public enum QuestionType
{
    Trivia,
    Poll
}

public class Question
{
    public int Id {get; private set; }
    public string Text { get; private set; }
    public IReadOnlyCollection<Answer> Answers { get; private set; }
    public bool HasCorrectAnswer {get; protected set;}
    public bool HasMultipleAnswers {get; protected set;}
    public QuestionType QuestionType {get; protected set;}
    
    public Question()
    {
        
    }

    public Question(string text, IReadOnlyCollection<Answer> answers)
    {
        if(answers is null)
        {   
            throw new ArgumentNullException("Value must be provided for 'Answers' property!");
        }
        if(string.IsNullOrEmpty(text))
        {   
            throw new ArgumentException("Value must be provided for 'Text' property !");
        }
        if(answers.Count < 2)
        {
            throw new ArgumentException($"Each question must have at least 2 answers!");
        }

        this.Text = text;
        this.Answers = answers;
    }

}
