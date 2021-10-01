using System.Collections.Generic;
using System.Threading.Tasks;
using Taste.SharedModels.Models;

namespace Taste.UIServices.IServices
{
    public interface IMenuItemService
    {
        Task<IEnumerable<MenuItemModel>> GetMenuItems();

        Task<MenuItemModel> GetMenuItemById(int menuItemId);

        Task<bool> AddMenuItem(MenuItemModel menuItem);

        Task<bool> UpdateMenuItem(MenuItemModel menuItem);

        Task<bool> DeleteMenuItem(int menuItemId);
    }
}
