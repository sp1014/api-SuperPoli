using Api_SuperPoli.Helpers;
using Api_SuperPoli.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api_SuperPoli.Core.LoginManager
{
    public interface ILoginManager
    {
        Task<ResultHelper<User>> LoginAsync(User user);
        Task<ResultHelper<User>> GetByIdAsync(string email);
    }
}
