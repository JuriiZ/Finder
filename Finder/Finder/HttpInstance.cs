using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Finder
{
    public static class HttpInstance
    {
        public static HttpClient _httpClient;
        public static HttpClient client
        {
            get
            {
                _httpClient = _httpClient ?? new HttpClient()
                {
                    BaseAddress = new Uri("https://reqres.in/api/"),
                    Timeout = TimeSpan.FromSeconds(60),
                };
                return _httpClient;
            }
        }

        public static void InitializeClient()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static void AssingToken(string token)
        {
            client.DefaultRequestHeaders.Authorization = new
                AuthenticationHeaderValue("Bearer", token);
        }
        public static void ClearHttpClientToken()
        {
            client.DefaultRequestHeaders.Authorization = null;
        }
    }
}
