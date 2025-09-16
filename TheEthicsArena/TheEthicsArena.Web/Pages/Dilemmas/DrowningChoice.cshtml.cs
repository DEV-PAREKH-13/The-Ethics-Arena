using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheEthicsArena.Web.Models;
using TheEthicsArena.Web.Services;

namespace TheEthicsArena.Web.Pages.Dilemmas
{
    public class DrowningChoiceModel : PageModel
    {
        private readonly DilemmaService _dilemmaService;
        public EthicalDilemma? Dilemma { get; set; }
        public DilemmaNavigation? Navigation { get; set; }

        public DrowningChoiceModel(DilemmaService dilemmaService)
        {
            _dilemmaService = dilemmaService;
        }

        public void OnGet()
        {
            Dilemma = _dilemmaService.GetDilemmaById(7);
            Navigation = _dilemmaService.GetNavigationForDilemma(7);
        }
        
        public IActionResult OnPost(string choice)
        {
            Dilemma = _dilemmaService.GetDilemmaById(7);
            Navigation = _dilemmaService.GetNavigationForDilemma(7);
            
            if (Dilemma == null) return Page();

            string userId = HttpContext.Session.GetString("UserID") ?? Guid.NewGuid().ToString();
            HttpContext.Session.SetString("UserID", userId);
            
            _dilemmaService.RecordResponse(userId, 7, choice, 0);
            
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
