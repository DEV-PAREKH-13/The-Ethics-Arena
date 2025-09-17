using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TheEthicsArena.Web.Pages.Admin
{
    [Authorize(Policy = "AdminOnly")]
    public class DashboardModel : PageModel
    {
        public void OnGet()
        {
            // You can leave empty or add any initialization here
        }
    }
}
