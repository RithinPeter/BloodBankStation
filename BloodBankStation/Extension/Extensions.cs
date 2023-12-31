﻿using BloodBankStation.GlobalValues;
using System.Net.Http;
using System.Threading.Tasks;

namespace BloodBankStation.Extension
{
    public static class Extensions
    {
        public static async Task<HttpResponseMessage> PatchAsync(this HttpClient client, string requestUri, HttpContent content)
        {
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("User-Key", GlobalData.APIKey);

            var method = new HttpMethod("PATCH");
            var request = new HttpRequestMessage(method, requestUri)
            {
                Content = content
            };

            var response = await client.SendAsync(request);
            return response;
        }
    }
}