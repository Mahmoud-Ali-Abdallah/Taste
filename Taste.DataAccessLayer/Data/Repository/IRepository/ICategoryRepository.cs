using System;
using System.Collections.Generic;
using System.Text;
using Taste.Models;
using Taste.Models.DTO;

namespace Taste.DataAccessLayer.Data.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<SelectListItemDTO> GetCategoryListFromDropDown();

        void Update(Category category);
    }
}
