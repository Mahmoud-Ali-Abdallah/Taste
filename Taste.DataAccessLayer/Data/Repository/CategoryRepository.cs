using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taste.DataAccessLayer.Data.Repository.IRepository;
using Taste.Models;
using Taste.Models.DTO;

namespace Taste.DataAccessLayer.Data.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext db;


        public CategoryRepository(ApplicationDbContext _db) : base(_db)
        {
            db = _db;
        }

        public IEnumerable<SelectListItemDTO> GetCategoryListFromDropDown()
        {
            return db.Categories.Select(
                cat => new SelectListItemDTO()
                {
                    Text = cat.Name,
                    Value = cat.Id
                }

                );
        }

        public void Update(Category category)
        {
            Category catFromDb = db.Categories.FirstOrDefault(s => s.Id == category.Id);

            catFromDb.Name = category.Name;
            catFromDb.DisplayOrder = category.DisplayOrder;

            // db.SaveChanges();
        }
    }
}
