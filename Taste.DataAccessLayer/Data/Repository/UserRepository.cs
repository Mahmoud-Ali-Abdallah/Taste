using System;
using System.Linq;
using Taste.DataAccessLayer.Data.Repository.IRepository;
using Taste.Models;

namespace Taste.DataAccessLayer.Data.Repository
{
    public class UserRepository : Repository<ApplicationUser>, IUserRepository
    {
        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
  
        public bool LockUnlock(string userId)
        {
            var objFromDb = _db.ApplicationUsers.FirstOrDefault(u => u.Id == userId);

            if (objFromDb == null)
            {
                return false;

            }
            if (objFromDb != null && objFromDb.LockoutEnd > DateTime.Now)
            {
                objFromDb.LockoutEnd = DateTime.Now;
            }
            else
            {
                objFromDb.LockoutEnd = DateTime.Now.AddYears(100);
            }

            return _db.SaveChanges() > 1 ? true : false;
        }
    }
}
