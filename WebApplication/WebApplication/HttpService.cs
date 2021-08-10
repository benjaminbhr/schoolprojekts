using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebApplication
{
    public static class HttpService
    {
        static readonly HttpClient client = new HttpClient();
        private static string BaseUrl = "https://";

        /// <summary>
        /// Http Get request using the provided url together with the baseUrl
        /// </summary>
        /// <param name="url">User inputted url</param>
        public static async Task<string> GetHttpResponse(string url)
        {
            HttpResponseMessage response = await client.GetAsync(BaseUrl + url);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsByteArrayAsync();
            string utfformatedResponse = Encoding.UTF8.GetString(responseBody);
            string formattedResponseFinal = Regex.Replace(utfformatedResponse, "<[^>]*>", String.Empty);

            return formattedResponseFinal;
        }
    }
}
