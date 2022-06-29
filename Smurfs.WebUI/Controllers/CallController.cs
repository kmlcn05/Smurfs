using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Smurfs.Entities.Conrete;
using Smurfs.WebUI.Services.Interfaces;

namespace Smurfs.WebUI.Controllers
{
    public class CallController : Controller
    {
        private ICallService _callService { get; set; }
        public CallController(ICallService callService)
        {
            _callService = callService;
        }
        public IActionResult Call()
        {
            return View();
        }

        public async Task<IActionResult> GetCallsFromAPI()
        {
            var calls = new List<Call>();

            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync("https://smuhammetulas.com/api/Call/GetCall"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    calls = JsonConvert.DeserializeObject<List<Call>>(apiResponse);
                }
            }
            return View("Call", calls);
        }
    }
}
