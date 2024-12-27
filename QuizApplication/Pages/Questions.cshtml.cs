using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuizApplication.Models;
using System.Linq;

namespace QuizApplication.Pages
{
    public class QuestionsModel : PageModel
    {
        private readonly QuizContext _context;

        public QuestionsModel(QuizContext context)
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

        public List<Question> Questions { get; set; }

        public void OnGet()
        {
            Questions = _context.Questions.ToList();
        }

        public IActionResult OnPostCreate()
        {
            if (Choices.Count == 0 || CorrectAnswer < 0 || CorrectAnswer >= Choices.Count)
            {
                ModelState.AddModelError(string.Empty, "Please provide valid choices and select a correct answer.");
                return Page();
            }

            var question = new Question
            {
                Text = QuestionText,
                Choices = Choices.ToArray(),
                CorrectAnswerIndex = CorrectAnswer,
                Score = Score
            };

            _context.Questions.Add(question);
            _context.SaveChanges();

            return RedirectToPage();
        }

        public IActionResult OnPostDelete(int id)
        {
            var question = _context.Questions.FirstOrDefault(q => q.Id == id);
            if (question != null)
            {
                _context.Questions.Remove(question);
                _context.SaveChanges();
            }

            return RedirectToPage();
        }
    }
}