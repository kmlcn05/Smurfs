using Core.Utilities.Results;
using Smurfs.Entities.Conrete;
using Smurfs.Entity.DTO_s;
using Smurfs.WebUI.Models;

namespace Smurfs.WebUI.Services
{
    public interface ILoginService
    {
        public Task<LoginUserDto> LoginAsync(string mail, string password);
    }
}
