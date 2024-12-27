using Microsoft.AspNetCore.Mvc.RazorPages;

namespace QuizApplication.Pages
{
    public class ScoreModel : PageModel
    {
        public int Score { get; set; }

        public void OnGet(int score)
        {
            Score = score;
        }
    }
}