using Guliver_Backend_Assignment.Domain;

namespace Guliver_Backend_Assignment.ApplicationCore.DTOs;
public class QuestionDto
{
    public int Id {get; set; }
    public string Text { get; set; }
    public IReadOnlyCollection<AnswerDto> Answers { get; set; }
    public bool HasCorrectAnswer {get; set;}
    public bool HasMultipleAnswers {get; set;}
    public QuestionType QuestionType {get; set;}
   
}
