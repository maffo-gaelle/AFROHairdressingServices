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
    public class UserService : IAuthRepository
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public void ActiveUser(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProfessionnalCategory> AllProfessionnalCategoryOfUser(int Id)
        {
            HttpResponseMessage httpResponseMessage = _httpClient.GetAsync($"api/user/professionnalCategories/{Id}").Result;
            httpResponseMessage.EnsureSuccessStatusCode();
            string json = httpResponseMessage.Content.ReadAsStringAsync().Result;

            return JsonSerializer.Deserialize<ProfessionnalCategory[]>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public int AverageStarsAvisByProfessionnal(int Id)
        {
            HttpResponseMessage httpResponseMessage = _httpClient.GetAsync($"api/user/Average/{Id}").Result;
            httpResponseMessage.EnsureSuccessStatusCode();
            string json = httpResponseMessage.Content.ReadAsStringAsync().Result;

            return JsonSerializer.Deserialize<int>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

        }

        public int CountAvisByProfessionnal(int Id)
        {
            HttpResponseMessage httpResponseMessage = _httpClient.GetAsync($"api/user/countAvis/{Id}").Result;
            httpResponseMessage.EnsureSuccessStatusCode();
            string json = httpResponseMessage.Content.ReadAsStringAsync().Result;

            return JsonSerializer.Deserialize<int>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public void Delete(int id)
        {
            HttpResponseMessage httpResponseMessage = _httpClient.DeleteAsync($"api/user/{id}").Result;
            
            httpResponseMessage.EnsureSuccessStatusCode();
        }

        public bool EmailExists(string email)
        {
            HttpResponseMessage httpResponseMessage = _httpClient.GetAsync($"api/user/EmailExists/{email}").Result;
            httpResponseMessage.EnsureSuccessStatusCode();
            string json = httpResponseMessage.Content.ReadAsStringAsync().Result;

            return JsonSerializer.Deserialize<bool>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }



        public User Get(int Id)
        {
            HttpResponseMessage httpResponseMessage = _httpClient.GetAsync($"api/user/{Id}").Result;
            httpResponseMessage.EnsureSuccessStatusCode();
            string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
            
            return JsonSerializer.Deserialize<User>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public IEnumerable<Avis> GetAllAvisByProfessionnal(int Id)
        {
            HttpResponseMessage httpResponseMessage = _httpClient.GetAsync($"api/user/AllAvis/{Id}").Result;
            httpResponseMessage.EnsureSuccessStatusCode();
            string json = httpResponseMessage.Content.ReadAsStringAsync().Result;

            return JsonSerializer.Deserialize<Avis[]>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public IEnumerable<User> GetAllProfessionnalUsersOrMemberUsers(int role)
        {
            HttpResponseMessage httpResponseMessage = _httpClient.GetAsync($"api/user/ByRole{role}").Result;
            httpResponseMessage.EnsureSuccessStatusCode();
            string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
            
            return JsonSerializer.Deserialize<User[]>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public IEnumerable<User> GetAllUser()
        {
            HttpResponseMessage httpResponseMessage = _httpClient.GetAsync("api/All").Result;
            httpResponseMessage.EnsureSuccessStatusCode();
            string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
            
            return JsonSerializer.Deserialize<User[]>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public User GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public User GetUserByFirstnameAndLastName(string firstname, string lastname)
        {
            throw new NotImplementedException();
        }

        public User GetUserByPseudo(string pseudo)
        {
            HttpResponseMessage httpResponseMessage = _httpClient.GetAsync($"api/user/userByPseudo/{pseudo}").Result;
            httpResponseMessage.EnsureSuccessStatusCode();
            string json = httpResponseMessage.Content.ReadAsStringAsync().Result;

            return JsonSerializer.Deserialize<User>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public User LoginClient(string email, string passwd)
        {
            string json = JsonSerializer.Serialize(new { email, passwd });
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage httpResponseMessage = _httpClient.PostAsync("api/user/login/Client", httpContent).Result;

            return httpResponseMessage.IsSuccessStatusCode ? JsonSerializer.Deserialize<User>(httpResponseMessage.Content.ReadAsStringAsync().Result, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }) : null;
        }

        public User LoginProfessionnal(string email, string passwd)
        {
            string json = JsonSerializer.Serialize(new { email, passwd });
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage httpResponseMessage = _httpClient.PostAsync("api/user/login/professionnal", httpContent).Result;

            return httpResponseMessage.IsSuccessStatusCode ? JsonSerializer.Deserialize<User>(httpResponseMessage.Content.ReadAsStringAsync().Result, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }) : null;
        }


        public bool PseudoExists(string pseudo)
        {
            HttpResponseMessage httpResponseMessage = _httpClient.GetAsync($"api/user/pseudoExists/{pseudo}").Result;
            httpResponseMessage.EnsureSuccessStatusCode();
            string json = httpResponseMessage.Content.ReadAsStringAsync().Result;

            return JsonSerializer.Deserialize<bool>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public User RegisterMember(User user)
        {
            string json = JsonSerializer.Serialize(user);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage httpResponseMessage = _httpClient.PostAsync("api/user/RegisterMember", httpContent).Result;
            
            httpResponseMessage.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<User>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
        public User RegisterProfessionnal(User user)
        {
            string json = JsonSerializer.Serialize(user);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage httpResponseMessage = _httpClient.PostAsync("api/user/RegisterProfessionnal", httpContent).Result;

            httpResponseMessage.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<User>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

        }

        public bool Update(int id, User user)
        {
            string json = JsonSerializer.Serialize(user);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage httpResponseMessage = _httpClient.PutAsync($"api/user/{id}", httpContent).Result;
            return httpResponseMessage.IsSuccessStatusCode;
        }

        //int IAuthRepository.RegisterProfessionnal(User user)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
