using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Finder.Services
{
    public static class ServicesAsync
    {
        public static async Task<HttpResponseMessage> GetUsersListAsync(HttpClient client, int page)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                try
                {
                    string url = $"users?page={page}";
                    response = await client.GetAsync(url);
                    return response;
                }
                catch (Exception e)
                {
                    HttpResponseMessage errorResponse = new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);
                    errorResponse.ReasonPhrase = e.Message;
                    return errorResponse;
                }
            }
            else
            {
                HttpResponseMessage errorResponse = new HttpResponseMessage();
                errorResponse.StatusCode = System.Net.HttpStatusCode.GatewayTimeout;
                errorResponse.ReasonPhrase = "Połączenie z internetem jest niedostępne";
                return errorResponse;
            }
        }
        public static async Task<HttpResponseMessage> GetUsersByIdAsync(HttpClient client, int id)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                try
                {
                    string url = $"users/{id}";
                    response = await client.GetAsync(url);
                    return response;
                }
                catch (Exception e)
                {
                    HttpResponseMessage errorResponse = new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);
                    errorResponse.ReasonPhrase = e.Message;
                    return errorResponse;
                }
            }
            else
            {
                HttpResponseMessage errorResponse = new HttpResponseMessage();
                errorResponse.StatusCode = System.Net.HttpStatusCode.GatewayTimeout;
                errorResponse.ReasonPhrase = "Połączenie z internetem jest niedostępne";
                return errorResponse;
            }
        }
        public static async Task<HttpResponseMessage> LoginRequestAsync(HttpClient client, string mail, string pass)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                try
                {
                    string url = $"login";
                    var contentObject = new
                    {
                        email = mail,
                        password = pass
                    };
                    StringContent content = new StringContent(JsonConvert.SerializeObject(contentObject), Encoding.UTF8, "application/json");
                    response = await client.PostAsync(url, content);
                    return response;
                }
                catch (Exception e)
                {
                    var errorResponse = new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);
                    errorResponse.ReasonPhrase = e.Message;
                    return errorResponse;
                }
            }
            else
            {
                HttpResponseMessage errorResponse = new HttpResponseMessage();
                errorResponse.StatusCode = System.Net.HttpStatusCode.GatewayTimeout;
                errorResponse.ReasonPhrase = "Połączenie z internetem jest niedostępne";
                return errorResponse;
            }
        }
    }
}
