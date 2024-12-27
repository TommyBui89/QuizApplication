using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuizApplication.Models;
using System.Linq;

namespace QuizApplication.Pages
{
    public class QuizModel : PageModel
    {
        private readonly QuizContext _context;

        public QuizModel(QuizContext context)
        {
            _context = context;
        }

        public List<Question> Questions { get; set; }

        public void OnGet()
        {
            Questions = _context.Questions.ToList();
        }

        public IActionResult OnPost([FromForm] Dictionary<int, int> answers)
        {
            int totalScore = 0;

            foreach (var answer in answers)
            {
                var question = _context.Questions.FirstOrDefault(q => q.Id == answer.Key);
                if (question != null && question.CorrectAnswerIndex == answer.Value)
                {
                    totalScore += question.Score; // Add the score for the correct answer
                }
            }

            return RedirectToPage("Score", new { score = totalScore });
        }
    }
}