namespace CompanyEmployee.Web.Controllers
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using CompanyEmployee.Web.Models;
    using CompanyEmployee.Web.Controllers;

    public class ApiClient : IApiClient
    {
        private readonly HttpClient httpClient;

        private Uri BaseEndpoint { get; set; }

        public ApiClient(HttpClient client)     
        {
            httpClient = client;
            BaseEndpoint = client.BaseAddress;
        }

        public async Task<T> GetAsync<T>(Uri requestUrl)
        {
            addHeaders();
            var response = await httpClient.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(data);
        }

        public async Task<Message<T>> PostAsync<T>(Uri requestUrl, T content)
        {
            addHeaders();
            var response = await httpClient.PostAsync(requestUrl.ToString(), CreateHttpContent<T>(content));
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Message<T>>(data);
        }

        public async Task DeleteAsync(Uri requestUrl)
        {
           await httpClient.DeleteAsync(requestUrl.ToString());
        }

        public async Task<Message<T1>> PostAsync<T1, T2>(Uri requestUrl, T2 content)
        {
            addHeaders();

            var response = await httpClient.PostAsync(requestUrl.ToString(), CreateHttpContent<T2>(content));

            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Message<T1>>(data);
        }

        public Uri CreateRequestUri(string relativePath, string queryString = "")
        {
            var endpoint = new Uri(BaseEndpoint, relativePath);
            var uriBuilder = new UriBuilder(endpoint);
            uriBuilder.Query = queryString;
            return uriBuilder.Uri;
        }

        public HttpContent CreateHttpContent<T>(T content)
        {
            var json = JsonConvert.SerializeObject(content, MicrosoftDateFormatSettings);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        public static JsonSerializerSettings MicrosoftDateFormatSettings
        {
            get
            {
                return new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                };
            }
        }

        public void addHeaders()
        {
            httpClient.DefaultRequestHeaders.Remove("userIP");
            httpClient.DefaultRequestHeaders.Add("userIP", "192.168.1.1");
        }
    }
}
