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
    public class LocalityService : ILocalityRepository
    {
        private readonly HttpClient _httpClient;

        public LocalityService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public void Add(Locality locality)
        {
            string json = JsonSerializer.Serialize(locality);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage httpResponseMessage = _httpClient.PostAsync("api/locality/", httpContent).Result;

            httpResponseMessage.EnsureSuccessStatusCode();

        }

        public void Delete(string codePostal)
        {
            throw new NotImplementedException();
        }

        public bool ExistsLocality(Locality locality)
        {
            throw new NotImplementedException();
        }

        public Locality Get(string codePostal)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Locality> Get()
        {
            throw new NotImplementedException();
        }

        public void Update(Locality locality)
        {
            throw new NotImplementedException();
        }
    }
}
