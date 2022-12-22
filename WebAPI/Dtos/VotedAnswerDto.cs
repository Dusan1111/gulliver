
namespace Guliver_Backend_Assignment.WebAPI.DTOs;
public class VotedAnswerDto
{
    public int NumberOfVotesPerAnswer { get; private set; }

    public VotedAnswerDto(int numberOfVotesPerAnswer)
    {
        this.NumberOfVotesPerAnswer = numberOfVotesPerAnswer;
    }
}