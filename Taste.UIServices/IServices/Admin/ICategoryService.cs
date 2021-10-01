using System.Collections.Generic;
using System.Threading.Tasks;
using Taste.SharedModels.Models;
using Taste.SharedModels.ViewModels;

namespace Taste.UIServices.IServices
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryModel>> GetCategories();

        Task<CategoryModel> GetCategoryById(int catId);

        Task<IEnumerable<SelectedListItemViewModel>> GetCategoryListForDropDown();

        Task<bool> AddCategory(CategoryModel category);

        Task<bool> UpdateCategory(CategoryModel category);

        Task<bool> DeleteCategory(int catId);



    }
}
