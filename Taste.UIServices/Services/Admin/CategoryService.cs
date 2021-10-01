using System.Collections.Generic;
using Taste.UIServices.IServices;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Taste.SharedModels.Models;
using Taste.SharedModels.ViewModels;

namespace Taste.UIServices.Services
{
    public class CategoryService : ICategoryService
    {
        public HttpClient Client { get; }

        public CategoryService(HttpClient client)
        {
            Client = client;
        }

        public async Task<IEnumerable<CategoryModel>> GetCategories()
        {
            var categories = await Client.GetFromJsonAsync<IEnumerable<CategoryModel>>("Category/GetCategories");

            return categories;
        }

        public async Task<CategoryModel> GetCategoryById(int catId)
        {
            return await Client.GetFromJsonAsync<CategoryModel>($"Category/GetCategoryById/{catId}");
        }

        public async Task<IEnumerable<SelectedListItemViewModel>> GetCategoryListForDropDown()
        {
            var categories = await Client.GetFromJsonAsync<IEnumerable<SelectedListItemViewModel>>
                ("Category/GetCategoryListForDropDown");

            return categories;
        }

        public async Task<bool> AddCategory(CategoryModel category)
        {
            var res = (await Client.PostAsJsonAsync<CategoryModel>($"Category/AddCategory", category));

            return res.Content.ReadFromJsonAsync<bool>().Result;
        }

        public Task<bool> UpdateCategory(CategoryModel category)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> DeleteCategory(int catId)
        {
             var res = (await Client.DeleteAsync($"Category/DeleteCategory/{catId}"));

             return (res.IsSuccessStatusCode) ? true : false;
        }

        
    }
}
