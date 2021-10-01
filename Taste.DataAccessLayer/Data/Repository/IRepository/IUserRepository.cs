using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taste.Models;

namespace Taste.DataAccessLayer.Data.Repository.IRepository
{
    public interface IUserRepository : IRepository<ApplicationUser>
    {
        bool LockUnlock(string userId);
    }
}
