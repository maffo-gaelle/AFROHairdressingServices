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
    public class ProfessionnalCategoryService : IProfessionnalCategoryRepository
    {
        private readonly HttpClient _httpClient;

        public ProfessionnalCategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public void Add(string name)
        {
            string json = JsonSerializer.Serialize(name);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage httpResponseMessage = _httpClient.PostAsync("api/ProfessionnalCategory", httpContent).Result;

            httpResponseMessage.EnsureSuccessStatusCode();
        }

        public void Delete(int id)
        {
            HttpResponseMessage httpResponseMessage = _httpClient.DeleteAsync($"api/ProfessionnalCategory/{id}").Result;

            httpResponseMessage.EnsureSuccessStatusCode();
        }

        public ProfessionnalCategory Get(int Id)
        {
            HttpResponseMessage httpResponseMessage = _httpClient.GetAsync($"api/ProfessionnalCategory/{Id}").Result;
            httpResponseMessage.EnsureSuccessStatusCode();
            string json = httpResponseMessage.Content.ReadAsStringAsync().Result;

            return JsonSerializer.Deserialize<ProfessionnalCategory>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public IEnumerable<ProfessionnalCategory> GetAll()
        {
            HttpResponseMessage httpResponseMessage = _httpClient.GetAsync($"api/ProfessionnalCategory").Result;
            httpResponseMessage.EnsureSuccessStatusCode();
            string json = httpResponseMessage.Content.ReadAsStringAsync().Result;

            return JsonSerializer.Deserialize<ProfessionnalCategory[]>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public ProfessionnalCategory GetProfessionnalCategoryByName(string name)
        {
            HttpResponseMessage httpResponseMessage = _httpClient.GetAsync($"api/ProfessionnalCategory/{name}").Result;
            httpResponseMessage.EnsureSuccessStatusCode();
            string json = httpResponseMessage.Content.ReadAsStringAsync().Result;

            return JsonSerializer.Deserialize<ProfessionnalCategory>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public IEnumerable<User> GetUsersByProfessionnalCategory(int id)
        {
            HttpResponseMessage httpResponseMessage = _httpClient.GetAsync($"api/ProfessionnalCategory/GetUsers/{id}").Result;
            httpResponseMessage.EnsureSuccessStatusCode();
            string json = httpResponseMessage.Content.ReadAsStringAsync().Result;

            return JsonSerializer.Deserialize<User[]>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public void Update(int id, ProfessionnalCategory category)
        {
            string json = JsonSerializer.Serialize(category);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage httpResponseMessage = _httpClient.PutAsync($"api/ProfessionnalCategory/{id}", httpContent).Result;
            
            httpResponseMessage.EnsureSuccessStatusCode();
        }
    }
}
