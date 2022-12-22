namespace Guliver_Backend_Assignment.Domain;

    public class Answer
    {
        public int Id {get; private set; }
        public string? Text { get; private set; }
        public bool IsCorrect { get; private set; }
        public Answer(){}
        public Answer(string text, bool isCorrect)
        {   
            if(string.IsNullOrEmpty(text))
            {   
                throw new ArgumentException("Value must be provided for Text  property !");
            }

            this.Text = text;
            this.IsCorrect = isCorrect;
        }
    }