using Core.Utilities.Results;
using Smurfs.Entities.Conrete;
using Smurfs.WebUI.Models;
using Newtonsoft.Json;

namespace Smurfs.WebUI.Services.Repositories
{
    public class LoginService : ILoginService
    {
        public async Task<User> LoginAsync(string mail, string password)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://smuhammetulas.com/api/Login/Login");

                var postTask = client.PostAsJsonAsync<Account>(client.BaseAddress, new Account
                {
                    Mail = mail,
                    Password = password
                });
                postTask.Wait();

                var result = postTask.Result;

                if(result.IsSuccessStatusCode)
                {
                    if (result.Content is object && result.Content.Headers.ContentType.MediaType == "application/json")
                    {
                        var stringResponse = await result.Content.ReadAsStringAsync();

                        return JsonConvert.DeserializeObject<User>(stringResponse);
                    }
                    else
                    {
                        return new User();
                    }
                }

                return new User();
            }
        }
    }
}
