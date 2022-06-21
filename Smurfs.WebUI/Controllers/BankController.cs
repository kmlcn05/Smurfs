using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Smurfs.Entities.Conrete;

namespace Smurfs.WebUI.Controllers
{
    public class BankController : Controller
    {
        public IActionResult Bank()
        {
            return View();
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
