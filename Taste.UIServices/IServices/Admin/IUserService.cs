using System.Collections.Generic;
using System.Threading.Tasks;
using Taste.SharedModels.Models;
using Taste.SharedModels.ViewModels.Account;
using Taste.Utility;

namespace Taste.UIServices.IServices.Admin
{
    public interface IUserService
    {
        Task<IEnumerable<ApplicationUserModel>> GetAllUsers();

        Task<ApplicationUserModel> GetUserById(string userId);

        Task<bool> LockUnlock(string userId);

        Task<Response<ApplicationUserModel>> RegisterUser(RegisterViewModel registerVM);

        void InjectTokenToHttp(string token);

        void Login(ApplicationUserModel model, string url);
        
    }
}
