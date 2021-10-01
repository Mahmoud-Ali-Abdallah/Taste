using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Taste.DataAccessLayer.Data.Repository.IRepository;
using Taste.Models;
using Taste.SharedModels.Models;

namespace Taste.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = UserRoles.Admin)]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork<IUserRepository> _unitOfWork;

        public UserController(IUnitOfWork<IUserRepository> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
       

        [HttpGet]
        [Route("GetAllUsers")]
        public IEnumerable<ApplicationUserModel> GetAllUsers()
        {
            var res = _unitOfWork.Repository.GetAll().Select(u => new ApplicationUserModel() {
                Id = u.Id,
                FullName = u.FirstName +" " + u.LastName,
                UserName = u.Email,
                PhoneNumber = u.PhoneNumber,
                LockOutEndDate = u.LockoutEnd
            });

            return res;
        }

        [HttpGet]
        [Route("GetUserById/{id}")]
        public ApplicationUser GetMenuItemById(string id)
        {
            return _unitOfWork.Repository.GetFirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        [Route("LockUnlock")]
        public bool LockUnlock([FromBody] string userId)
        {
            return _unitOfWork.Repository.LockUnlock(userId);
        }

    }
}
