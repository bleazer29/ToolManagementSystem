using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ToolManagementSystem.Client
{
    public class CustomHttpClient
    {
         private static HttpClient httpClient { get; set; }
        
         private static string baseURL = "http://localhost:5000/api/";

         public static HttpClient GetClientInstance()
         {
            if (httpClient == null)
            {
                httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(baseURL);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
            }
            return httpClient;
         }
    }
}
