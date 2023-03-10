using System.Net.Http.Headers;
using System.Net.Http;
using System;
using Microsoft.AspNetCore.Http;

namespace ClientMVC
{
    public static class GobalVariables
    {
        public static HttpClient WebAPIClient = new();

        static GobalVariables()
        {
            //WebAPIClient.BaseAddress = new Uri("https://localhost:44362/api/"); // service api
            WebAPIClient.BaseAddress = new Uri("https://localhost:44364/api/apigateway/"); // service api gateway
            WebAPIClient.DefaultRequestHeaders.Clear();
            WebAPIClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static void AddAuthorizationHeader(this HttpClient client, string token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }
}
