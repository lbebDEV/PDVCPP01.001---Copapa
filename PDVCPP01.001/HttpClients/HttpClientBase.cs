using Newtonsoft.Json;
using PDVCPP01._001.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PDVCPP01._001.HttpClients
{
    public class HttpClientBase<T> where T : class
    {
        protected readonly HttpClient _client;

        public HttpClientBase(string url)
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(url);
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.Add("token", Service_Config.Token);
        }

        public T Get(string path)
        {
            var response = _client.GetStringAsync(path).Result;
            var entity = JsonConvert.DeserializeObject<T>(response);
            return entity;
        }

        public List<T> GetAll(string path)
        {
            var response = _client.GetStringAsync(path).Result;
            var entities = JsonConvert.DeserializeObject<List<T>>(response);

            return entities;
        }
    }
}
