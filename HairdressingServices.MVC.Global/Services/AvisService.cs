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
    public class AvisService : IAvisRepository
    {
        private readonly HttpClient _httpClient;

        public AvisService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Avis Get(int id)
        {
            HttpResponseMessage httpResponseMessage = _httpClient.GetAsync($"api/avis/{id}").Result;
            httpResponseMessage.EnsureSuccessStatusCode();
            string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
            
            return JsonSerializer.Deserialize<Avis>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public IEnumerable<Avis> GetAllAvisByProfessionnal(int Id)
        {
            HttpResponseMessage httpResponseMessage = _httpClient.GetAsync($"api/avis/AvisByProfessionnal/{Id}").Result;
            httpResponseMessage.EnsureSuccessStatusCode();
            string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
            
            return JsonSerializer.Deserialize<Avis[]>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public IEnumerable<Comment> GetAllCommentByAvis(int id)
        {
            HttpResponseMessage httpResponseMessage = _httpClient.GetAsync($"api/avis/CommentsByAvis/{id}").Result;
            httpResponseMessage.EnsureSuccessStatusCode();
            string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
            return JsonSerializer.Deserialize<Comment[]>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public bool Insert(Avis avis)
        {
            string json = JsonSerializer.Serialize(avis);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage httpResponseMessage = _httpClient.PostAsync("api/avis/", httpContent).Result;
            return httpResponseMessage.IsSuccessStatusCode;
        }

        public bool Update(int id, Avis avis)
        {
            string json = JsonSerializer.Serialize(avis);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage httpResponseMessage = _httpClient.PutAsync($"api/avis/{id}", httpContent).Result;
            return httpResponseMessage.IsSuccessStatusCode;
        }
    }
}
