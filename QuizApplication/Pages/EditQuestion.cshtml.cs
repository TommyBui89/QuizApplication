using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuizApplication.Models;
using System.Linq;

namespace QuizApplication.Pages
{
    public class EditQuestionModel : PageModel
    {
        private readonly QuizContext _context;

        public EditQuestionModel(QuizContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string QuestionText { get; set; }

        [BindProperty]
        public List<string> Choices { get; set; } = new List<string>();

        [BindProperty]
        public int CorrectAnswer { get; set; }

        [BindProperty]
        public int Score { get; set; }

        public IActionResult OnGet(int id)
        {
            var question = _context.Questions.FirstOrDefault(q => q.Id == id);
            if (question == null)
            {
                return RedirectToPage("/Questions");
            }

            QuestionText = question.Text;
            Choices = question.Choices.ToList();
            CorrectAnswer = question.CorrectAnswerIndex;
            Score = question.Score;

            return Page();
        }

        public IActionResult OnPost(int id)
        {
            var question = _context.Questions.FirstOrDefault(q => q.Id == id);
            if (question != null)
            {
                question.Text = QuestionText;
                question.Choices = Choices.ToArray();
                question.CorrectAnswerIndex = CorrectAnswer;
                question.Score = Score;

                _context.SaveChanges();
            }

            return RedirectToPage("/Questions");
        }
    }
}