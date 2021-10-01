using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Taste.SharedModels.Models;
using Taste.SharedModels.ViewModels;
using Taste.UIServices.IServices;

namespace Taste.UIServices.Services
{
    public class FoodTypeService : IFoodTypeService
    {
        public HttpClient Client { get; }

        public FoodTypeService(HttpClient client)
        {
            Client = client;
        }

        public async Task<IEnumerable<FoodTypeModel>> GetFoodTypes()
        {
            var foodTypes = await Client.GetFromJsonAsync<IEnumerable<FoodTypeModel>>("FoodType/GetFoodTypes");

            return foodTypes;
        }


        public async Task<FoodTypeModel> GetFoodTypeById(int foodTypeId)
        {
            return await Client.GetFromJsonAsync<FoodTypeModel>($"FoodType/GetFoodTypeById/{foodTypeId}");
        }

        public async Task<IEnumerable<SelectedListItemViewModel>> GetFoodTypeListForDropDown()
        {
            var foodTypes = await Client.GetFromJsonAsync<IEnumerable<SelectedListItemViewModel>>
                ("FoodType/GetFoodTypeListForDropDown");

            return foodTypes;
        }

        public async Task<bool> AddFoodType(FoodTypeModel foodType)
        {
            var res = (await Client.PostAsJsonAsync<FoodTypeModel>($"FoodType/AddFoodType", foodType));

            return res.Content.ReadFromJsonAsync<bool>().Result;
        }

        public Task<bool> UpdateFoodType(FoodTypeModel foodType)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteFoodType(int foodTypeId)
        {
            var res = (await Client.DeleteAsync($"FoodType/DeleteFoodType/{foodTypeId}"));

            return (res.IsSuccessStatusCode) ? true : false;
        }
       
    }
}
