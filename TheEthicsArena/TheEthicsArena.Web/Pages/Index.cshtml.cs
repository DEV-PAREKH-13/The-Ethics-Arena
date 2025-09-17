using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TheEthicsArena.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public bool IsAdmin { get; private set; }

        public IndexModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void OnGet()
        {
            var user = _httpContextAccessor.HttpContext?.User;
            IsAdmin = user?.IsInRole("Admin") ?? false;
        }
        public IActionResult OnPostStart(string userName)
{
    HttpContext.Session.SetString("UserName", userName);
    return RedirectToPage("/Dilemmas/TrolleyProblem");
}

    }
}
