using Api_SuperPoli.Helpers;
using Api_SuperPoli.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api_SuperPoli.Core.UserManager
{
    public interface IUserManager
    {
        Task<ResultHelper<IEnumerable<User>>> GetUsersAsync();
        Task<ResultHelper<User>> GetByIdAsync(int id);
        Task<ResultHelper<IEnumerable<User>>> GetByIdRolAsync(int idRol);
        Task<ResultHelper<User>> CreateAsync(User user);
        Task<ResultHelper<User>> UpdateAsync(User user, int id);
        // Task<ResultHelper<User>> GetByIdListAsync(int id);


    }
}