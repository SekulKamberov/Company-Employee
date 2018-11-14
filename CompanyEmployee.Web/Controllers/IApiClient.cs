namespace CompanyEmployee.Web.Controllers
{
    using CompanyEmployee.Web.Models;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;

    public interface IApiClient
    {
        Task<T> GetAsync<T>(Uri requestUrl);

        Task<Message<T>> PostAsync<T>(Uri requestUrl, T content);

        Task<Message<T1>> PostAsync<T1, T2>(Uri requestUrl, T2 content);

        Task DeleteAsync(Uri requestUrl);

        Uri CreateRequestUri(string relativePath, string queryString = "");

        HttpContent CreateHttpContent<T>(T content);

        void addHeaders();
    }
}
