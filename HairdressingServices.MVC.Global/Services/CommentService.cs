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
    public class CommentService : ICommentRepository
    {
        private readonly HttpClient _httpClient;

        public CommentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public void Delete(int userId, int id)
        {
            HttpResponseMessage httpResponseMessage = _httpClient.DeleteAsync($"api/comment/{id}").Result;

            httpResponseMessage.EnsureSuccessStatusCode();
        }

        public Comment Get(int Id)
        {
            HttpResponseMessage httpResponseMessage = _httpClient.GetAsync($"api/Comment/{Id}").Result;
            httpResponseMessage.EnsureSuccessStatusCode();
            string json = httpResponseMessage.Content.ReadAsStringAsync().Result;

            return JsonSerializer.Deserialize<Comment>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public IEnumerable<Comment> GetCommentByAvis(int Id)
        {
            HttpResponseMessage httpResponseMessage = _httpClient.GetAsync($"api/Comment/{Id}").Result;
            httpResponseMessage.EnsureSuccessStatusCode();
            string json = httpResponseMessage.Content.ReadAsStringAsync().Result;

            return JsonSerializer.Deserialize<Comment[]>(json, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });
        }

        public User GetUserComment(Comment comment)
        {
            throw new NotImplementedException();
        }

        public void Insert(Comment comment)
        {
            string json = JsonSerializer.Serialize(comment);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage httpResponseMessage = _httpClient.PostAsync("api/comment", httpContent).Result;

            httpResponseMessage.EnsureSuccessStatusCode();
        }

        public void Update(int id, Comment comment)
        {
            string json = JsonSerializer.Serialize(comment);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage httpResponseMessage = _httpClient.PutAsync($"api/comment/{id}", httpContent).Result;
            httpResponseMessage.EnsureSuccessStatusCode();
        }
    }
}
