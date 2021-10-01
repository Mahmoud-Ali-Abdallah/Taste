using System.Collections.Generic;
using System.Linq;
using Taste.DataAccessLayer.Data.Repository.IRepository;
using Taste.Models;
using Taste.Models.DTO;

namespace Taste.DataAccessLayer.Data.Repository
{
    public class FoodTypeRepository : Repository<FoodType>, IFoodTypeRepository
    {
        private readonly ApplicationDbContext db;

        public FoodTypeRepository(ApplicationDbContext _db) : base(_db)
        {
            db = _db;
        }

        public IEnumerable<SelectListItemDTO> GetFoodTypeListFromDropDown()
        {
            return db.FoodTypes.Select(
                type => new SelectListItemDTO()
                {
                    Text = type.Name,
                    Value = type.Id
                }

                );
        }

        public void Update(FoodType foodType)
        {
            Category catFromDb = db.Categories.FirstOrDefault(s => s.Id == foodType.Id);

            // Use mapper instead to it manual
            catFromDb.Name = foodType.Name;
            
        }
    }
}
