using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

public class LoginModel : PageModel
{
    public IActionResult OnGet() => Page();

    public async Task<IActionResult> OnPostAsync(string username, string password)
    {
        // For demo: hardcoded admin username/password
        if (username == "Dev" && password == "Dev123")
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, "Admin")
            };
            var identity = new ClaimsIdentity(claims, "MyCookieAuth");
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync("MyCookieAuth", principal);

            return RedirectToPage("/Admin/Dashboard");
        }

        ModelState.AddModelError("", "Invalid credentials");
        return Page();
    }
}