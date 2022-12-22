using Xunit;
using Guliver_Backend_Assignment.Domain;
using FluentAssertions;
namespace Guliver_Backend_Assignment.UnitTests.DomainTests;

public class QuestionTests
{

        [Fact]
        public void CreateQuestion_WithNonExistingAnswers_ReturnsArgumentNullException()
        {
            // Arange
            Action createQuestion = () => new Question("Test question?", null);
            
            createQuestion.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void CreateQuestion_WithEmptyAnswerList_ReturnsArgumentException()
        {
            // Arange
            IReadOnlyCollection<Answer> answers = new  List<Answer>();
            Action createQuestion = () => new Question("Test question?", answers);
            
            createQuestion.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void CreateQuestion_WithEmptyQuestionText_ReturnsArgumentException()
        {
            // Arange
            IReadOnlyCollection<Answer> answers = new  List<Answer>();
            Action createQuestion = () => new Question(string.Empty, answers);
            
            createQuestion.Should().Throw<ArgumentException>();
        }
         [Fact]
        public void CreateQuestion_WithNonExistingQuestionText_ReturnsArgumentException()
        {
            // Arange
            IReadOnlyCollection<Answer> answers = new  List<Answer>();
            Action createQuestion = () => new Question(null, answers);
            
            createQuestion.Should().Throw<ArgumentException>();
        }

}
