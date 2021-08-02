using HairdressingServices.MVC.Global.Data;
using HairdressingServices.MVC.Global.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HairdressingServices.MVC.Global.Services
{
    public class UserCategoryProfessionnalService : IUserCategoryProfessionnalRepository
    {
        private readonly HttpClient _httpClient;

        public UserCategoryProfessionnalService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public void Add(UserCategoryProfessionnal userCategoryProfessionnal)
        {
            string json = JsonSerializer.Serialize(userCategoryProfessionnal);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage httpResponseMessage = _httpClient.PostAsync("api/UserCategoryProfessionnal/", httpContent).Result;

            httpResponseMessage.EnsureSuccessStatusCode();
        }

        public void delete(int userId, int id)
        {
            HttpResponseMessage httpResponseMessage = _httpClient.DeleteAsync($"api/UserCategoryProfessionnal/{userId}/{id}").Result;

            httpResponseMessage.EnsureSuccessStatusCode();
        }

        public ProfessionnalCategory GetProfessionnalCategoryNameById(int Id)
        {
            HttpResponseMessage httpResponseMessage = _httpClient.GetAsync($"api/UserCategoryProfessionnal/{Id}").Result;
            httpResponseMessage.EnsureSuccessStatusCode();
            string json = httpResponseMessage.Content.ReadAsStringAsync().Result;

            return JsonSerializer.Deserialize<ProfessionnalCategory>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public IEnumerable<User> GetUsersByProfessionnalCategory(int Id)
        {
            HttpResponseMessage httpResponseMessage = _httpClient.GetAsync($"api/UserCategoryProfessionnal/GetUsers/{Id}").Result;
            httpResponseMessage.EnsureSuccessStatusCode();
            string json = httpResponseMessage.Content.ReadAsStringAsync().Result;

            return JsonSerializer.Deserialize<User[]>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
