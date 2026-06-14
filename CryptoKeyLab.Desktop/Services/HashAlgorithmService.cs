using CryptoKeyLab.Desktop.Interfaces;
using CryptoKeyLab.Desktop.Models.Configuration;
using CryptoKeyLab.Desktop.Models.Response;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace CryptoKeyLab.Desktop.Services
{
    public class HashAlgorithmService : IHashAlgorithmService
    {
        private readonly IOptions<AppSettingModel> _options;
        private readonly HttpClient _httpClient;
        public HashAlgorithmService(IOptions<AppSettingModel> options,HttpClient httpClient)
        {
            _options = options;
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<HashAlgorithmsResponse>> GetHashAlgorithmsAsync()
        {
            var url = $"{_options.Value.ApiBaseUrl}Hash/Algorithms";

            //1.create custom http get request
            using var httpRequest = new HttpRequestMessage(HttpMethod.Get,url);

            //2.create header for the request
            httpRequest.Headers.Add(_options.Value.ApiHeaderName,_options.Value.ApiKey);

            //3.send the request using httpclient
            var httpResponse = await _httpClient.SendAsync(httpRequest);

            //4.throw if the response is not successful
            httpResponse.EnsureSuccessStatusCode();

            //5.read and deserialize the json response content into a list of HashAlgorithmsResponse
            var data = await httpResponse.Content.ReadFromJsonAsync<IEnumerable<HashAlgorithmsResponse>>();

            //6. return the data or an empty list if data is null
            return data ?? Enumerable.Empty<HashAlgorithmsResponse>();
        }
    }
}
