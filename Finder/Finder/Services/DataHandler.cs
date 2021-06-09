using Finder.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json;

namespace Finder.Services
{
    public static class DataHandler
    {
        public static async Task<UserResponseModel> ReadUsersResponse(HttpResponseMessage httpResponse)
        {
            UserResponseModel responseModel = new UserResponseModel();

            if (httpResponse.Content != null)
            {
                try
                {
                    var content = await httpResponse.Content.ReadAsStringAsync();
                    responseModel = JsonConvert.DeserializeObject<UserResponseModel>(content);
                    return responseModel;
                }
                catch (Exception e)
                {
                    return responseModel;
                }
            }

            return responseModel;
        }

        public static async Task<UserByIdModel> ReadUserByIdResponse(HttpResponseMessage httpResponse)
        {
            UserByIdModel responseModel = new UserByIdModel();

            if (httpResponse.Content != null)
            {
                try
                {
                    var content = await httpResponse.Content.ReadAsStringAsync();
                    responseModel = JsonConvert.DeserializeObject<UserByIdModel>(content);
                    return responseModel;
                }
                catch (Exception e)
                {
                    return responseModel;
                }
            }

            return responseModel;
        }
    }
}
