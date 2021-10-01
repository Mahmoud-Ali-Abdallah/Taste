using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Taste.SharedModels.Models;
using Taste.UIServices.IServices;

namespace Taste.UIServices.Services
{
    public class MenuItemService : IMenuItemService
    {
        private HttpClient Client { get; }

        public MenuItemService(HttpClient client)
        {
            Client = client;
        }

        public async Task<bool> AddMenuItem(MenuItemModel menuItem)
        {
            var res = (await Client.PostAsJsonAsync<MenuItemModel>($"MenuItem/AddMenuItem", menuItem));

            return res.Content.ReadFromJsonAsync<bool>().Result;
        }

        public async Task<bool> DeleteMenuItem(int menuItemId)
        {
            var res = (await Client.DeleteAsync($"MenuItem/DeleteMenuItem/{menuItemId}"));

            return (res.IsSuccessStatusCode) ? true : false;
        }

        public async Task<MenuItemModel> GetMenuItemById(int menuItemId)
        {
            return await Client.GetFromJsonAsync<MenuItemModel>($"MenuItem/GetMenuItemById/{menuItemId}");
        }

        public async Task<IEnumerable<MenuItemModel>> GetMenuItems()
        {
            var menuItems = await Client.GetFromJsonAsync<IEnumerable<MenuItemModel>>("MenuItem/GetMenuItems");

            return menuItems;
        }

        public async Task<bool> UpdateMenuItem(MenuItemModel menuItem)
        {
            throw new NotImplementedException();
        }


    }
}
