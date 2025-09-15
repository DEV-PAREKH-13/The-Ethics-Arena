using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TheEthicsArena.Web.Pages.Dilemmas
{
    public class TrolleyProblemModel : PageModel
    {
        public void OnGet()
        {
        }
        
        public IActionResult OnPost(string choice)
        {
            if (choice == "pull")
            {
                ViewData["Result"] = "You chose to pull the lever. You saved 5 lives but sacrificed 1.";
                ViewData["ResultClass"] = "alert-warning";
            }
            else if (choice == "nothing")
            {
                ViewData["Result"] = "You chose to do nothing. 5 people died, but you didn't directly cause anyone's death.";
                ViewData["ResultClass"] = "alert-info";
            }
            
            return Page();
        }
    }
}
