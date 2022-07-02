using Core.Utilities.Results;
using Smurfs.Entities.Conrete;
using Smurfs.WebUI.Models;
using Newtonsoft.Json;
using Smurfs.Entity.DTO_s;
using System.Text;
using System.Security.Cryptography;

namespace Smurfs.WebUI.Services.Repositories
{
    public class LoginService : ILoginService
    {
        public async Task<LoginUserDto> LoginAsync(string mail, string password)
        {
            using(var client = new HttpClient())
            {
                string hashPassword = sha256_hash(password);


                client.BaseAddress = new Uri("https://smuhammetulas.com/api/Login/Login");

                var postTask = client.PostAsJsonAsync<Account>(client.BaseAddress, new Account
                {
                    Mail = mail,
                    Password = hashPassword
                });
                postTask.Wait();

                var result = postTask.Result;

                if(result.IsSuccessStatusCode)
                {
                    if (result.Content is object && result.Content.Headers.ContentType.MediaType == "application/json")
                    {
                        var stringResponse = await result.Content.ReadAsStringAsync();

                        return JsonConvert.DeserializeObject<LoginUserDto>(stringResponse);
                    }
                    else
                    {
                        return new LoginUserDto();
                    }
                }

                return new LoginUserDto();
            }
        }
        public static String sha256_hash(String value)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }
    }
}
