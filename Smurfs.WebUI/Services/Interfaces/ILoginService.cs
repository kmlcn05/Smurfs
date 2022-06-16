using Core.Utilities.Results;
using Smurfs.Entities.Conrete;
using Smurfs.WebUI.Models;

namespace Smurfs.WebUI.Services
{
    public interface ILoginService
    {
        public Task<User> LoginAsync(string mail, string password);
    }
}
