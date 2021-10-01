using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taste.DataAccessLayer.Data.Repository.IRepository;
using Taste.Models;

namespace Taste.DataAccessLayer.Data.Repository
{
    public class MenuItemRepository : Repository<MenuItem>, IMenuItemRepository
    {
        private readonly ApplicationDbContext _db;


        public MenuItemRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(MenuItem menuItem)
        {
            MenuItem menuItemFromDb = _db.MenuItems.FirstOrDefault(s => s.Id == menuItem.Id);

            // Replace it with mapper
            menuItemFromDb.Name = menuItem.Name;
            menuItemFromDb.Description = menuItem.Description;
            menuItemFromDb.Price = menuItem.Price;
            menuItemFromDb.CategoryId = menuItem.CategoryId;
            menuItemFromDb.FoodTypeId = menuItem.FoodTypeId;
            if (menuItemFromDb.Image != null)
            {
                menuItemFromDb.Image = menuItem.Image;
            }

            _db.SaveChanges();
        }
    }
}
