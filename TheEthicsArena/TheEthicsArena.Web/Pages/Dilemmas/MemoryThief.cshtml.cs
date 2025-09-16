using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheEthicsArena.Web.Models;
using TheEthicsArena.Web.Services;

namespace TheEthicsArena.Web.Pages.Dilemmas
{
    public class MemoryThiefModel : PageModel
    {
        private readonly DilemmaService _dilemmaService;
        public EthicalDilemma? Dilemma { get; set; }
        public DilemmaNavigation? Navigation { get; set; }

        public MemoryThiefModel(DilemmaService dilemmaService)
        {
            _dilemmaService = dilemmaService;
        }

        public void OnGet()
        {
            Dilemma = _dilemmaService.GetDilemmaById(6);
            Navigation = _dilemmaService.GetNavigationForDilemma(6);
        }
        
        public async Task<IActionResult> OnPostAsync(string choice)
        {
            Dilemma = _dilemmaService.GetDilemmaById(6);
            Navigation = _dilemmaService.GetNavigationForDilemma(6);
            
            if (Dilemma == null) return Page();

            string userId = HttpContext.Session.GetString("UserID") ?? Guid.NewGuid().ToString();
            HttpContext.Session.SetString("UserID", userId);
            
            // Save to MongoDB
            await _dilemmaService.RecordResponseAsync(userId, 6, choice, 0);
            
            // Get stats from MongoDB
            var stats = await _dilemmaService.GetResponseStatsAsync(6);
            int total = stats["A"] + stats["B"];
            int percentA = total > 0 ? (int)Math.Round((double)stats["A"] / total * 100) : 50;
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
