using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Taste.SharedModels.Models;
using Taste.SharedModels.ViewModels.Account;
using Taste.UIServices.IServices.Admin;
using Taste.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Components;

namespace Taste.UIServices.Services.Admin
{
    public class UserService : Controller, IUserService
    {

        private readonly HttpClient _client;
        private readonly NavigationManager _navigation;


        public UserService(HttpClient client, NavigationManager navigation)
        {
            _client = client;
            _navigation = navigation;

        }

        public async Task<IEnumerable<ApplicationUserModel>> GetAllUsers()
        {
            var users = await _client.GetFromJsonAsync<IEnumerable<ApplicationUserModel>>("User/GetAllUsers");

            return users;
        }

        public async Task<ApplicationUserModel> GetUserById(string userId)
        {
            var user = await _client.GetFromJsonAsync<ApplicationUserModel>("User/GetUserById");

            return user;
        }


        public async Task<bool> LockUnlock(string userId)
        {
            var res = (await _client.PostAsJsonAsync<string>($"User/LockUnlock", userId));

            return res.Content.ReadFromJsonAsync<bool>().Result;
        }

        public async Task<Response<ApplicationUserModel>> RegisterUser(RegisterViewModel registerUser)
        {
            var res = (await _client.PostAsJsonAsync<RegisterViewModel>($"Authentication/register", registerUser));

            // Check if res != null 
            return res.Content.ReadFromJsonAsync<Response<ApplicationUserModel>>().Result;
        }

        public void InjectTokenToHttp(string token)
        {
            _client.DefaultRequestHeaders.Authorization
             = new AuthenticationHeaderValue("Bearer", token);
        }

        public void Login(ApplicationUserModel model, string url)
        {
            _navigation.NavigateTo($"/authenticate?username={model.UserName}&pwd=" +
                           $"{model.Password}&url={url}", true);
        }
    }
}
