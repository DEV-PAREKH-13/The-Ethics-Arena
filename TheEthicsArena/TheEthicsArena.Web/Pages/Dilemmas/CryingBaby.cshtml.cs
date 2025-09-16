using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheEthicsArena.Web.Models;
using TheEthicsArena.Web.Services;

namespace TheEthicsArena.Web.Pages.Dilemmas
{
    public class CryingBabyModel : PageModel
    {
        private readonly DilemmaService _dilemmaService;
        public EthicalDilemma? Dilemma { get; set; }
        public DilemmaNavigation? Navigation { get; set; }

        public CryingBabyModel(DilemmaService dilemmaService)
        {
            _dilemmaService = dilemmaService;
        }

        public void OnGet()
        {
            Dilemma = _dilemmaService.GetDilemmaById(2);
            Navigation = _dilemmaService.GetNavigationForDilemma(2);
        }
        
        public IActionResult OnPost(string choice)
        {
            Dilemma = _dilemmaService.GetDilemmaById(2);
            Navigation = _dilemmaService.GetNavigationForDilemma(2);
            
            if (Dilemma == null) return Page();

            // Generate or get user ID
            string userId = HttpContext.Session.GetString("UserID") ?? Guid.NewGuid().ToString();
            HttpContext.Session.SetString("UserID", userId);
            
            // Record the response
            _dilemmaService.RecordResponse(userId, 2, choice, 0);
            
            // Calculate percentages
            int total = Dilemma.ResponsesA + Dilemma.ResponsesB;
            int percentA = total > 0 ? (int)Math.Round((double)Dilemma.ResponsesA / total * 100) : 50;
            int percentB = 100 - percentA;
            
            ViewData["Result"] = true;
            ViewData["Choice"] = choice;
            ViewData["ChoiceText"] = choice == "A" ? Dilemma.OptionA : Dilemma.OptionB;
            ViewData["PercentageA"] = percentA;
            ViewData["PercentageB"] = percentB;
            
            return Page();
        }
    }
}
