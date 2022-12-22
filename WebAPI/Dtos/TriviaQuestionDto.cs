namespace Guliver_Backend_Assignment.WebAPI.DTOs;
public class TriviaVotedAnswerDto : VotedAnswerDto
{
    public bool IsCorrect { get; private set; }

    public TriviaVotedAnswerDto(int numberOfVotesPerAnswer, bool isCorrect)
        : base(numberOfVotesPerAnswer)
    {
        this.IsCorrect = isCorrect;
    }

}