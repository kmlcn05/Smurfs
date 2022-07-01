using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Smurfs.Entities.Conrete;

namespace Smurfs.WebUI.Controllers
{
    public class BankController : Controller
    {
        public IActionResult Bank()
        {
            if (HttpContext.Session.GetString("UserRole") == "Admin"
                || HttpContext.Session.GetString("UserRole") == "Manager")
            {
                ViewBag.Username = HttpContext.Session.GetString("LoggedUser");
                ViewBag.Usergruop = HttpContext.Session.GetString("UserRole");

                return View();
            }
            else
                return View("NotAuthorized");
        }
        public async Task<IActionResult> GetBanksFromAPI()
        {
            var banks = new List<Bank>();

            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync("https://smuhammetulas.com/api/Bank"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    banks = JsonConvert.DeserializeObject<List<Bank>>(apiResponse);

                    return Ok(apiResponse);
                }
            }

        }
    }
}
