using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Models;

namespace WebUI.Views.Login
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public LoginUserModal LoginUserModal { get; set; }
        public void OnGet()
        {
        }
    }
}
