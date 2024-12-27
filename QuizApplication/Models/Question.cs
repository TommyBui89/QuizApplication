namespace QuizApplication.Models
{
    public class Question
    {
        public int Id { get; set; } // Unique identifier for the question
        public string Text { get; set; } // The text of the question
        public string[] Choices { get; set; } // Array of multiple-choice answers
        public int CorrectAnswerIndex { get; set; } // Index of the correct answer in the Choices array
        public int Score { get; set; } // Points assigned to this question
    }
}