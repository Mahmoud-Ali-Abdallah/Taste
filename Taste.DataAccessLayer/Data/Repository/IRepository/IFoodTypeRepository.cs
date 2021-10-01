using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Taste.Models;
using Taste.Models.DTO;

namespace Taste.DataAccessLayer.Data.Repository.IRepository
{
    public interface IFoodTypeRepository : IRepository<FoodType>
    {
        IEnumerable<SelectListItemDTO> GetFoodTypeListFromDropDown();

        void Update(FoodType foodType);
    }
}
