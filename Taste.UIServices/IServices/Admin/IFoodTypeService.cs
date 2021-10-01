using System.Collections.Generic;
using System.Threading.Tasks;
using Taste.SharedModels.Models;
using Taste.SharedModels.ViewModels;

namespace Taste.UIServices.IServices
{
    public interface IFoodTypeService
    {
        Task<IEnumerable<FoodTypeModel>> GetFoodTypes();

        Task<FoodTypeModel> GetFoodTypeById(int foodTypeId);

        Task<IEnumerable<SelectedListItemViewModel>> GetFoodTypeListForDropDown();

        Task<bool> AddFoodType(FoodTypeModel foodType);

        Task<bool> UpdateFoodType(FoodTypeModel foodType);

        Task<bool> DeleteFoodType(int foodTypeId);
    }
}
