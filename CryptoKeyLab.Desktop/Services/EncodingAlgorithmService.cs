using CryptoKeyLab.Desktop.Interfaces;
using CryptoKeyLab.Desktop.Models.Configuration;
using CryptoKeyLab.Desktop.Models.Response;
using Microsoft.EntityFrameworkCore.Migrations;
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
    public class EncodingAlgorithmService : IEncodingAlgorithmService
    {
        private readonly HttpClient _httpClient;
        private readonly IOptions<AppSettingModel> _options;

        public EncodingAlgorithmService(HttpClient httpClient, IOptions<AppSettingModel> options)
        {
            _httpClient = httpClient;
            _options = options;
        }

        public async Task<ApiResponse> ComputeEncodingAsync(string AlgoName, string encodingData)
        {
            //1.creating url
            string url = $"{_options.Value.ApiBaseUrl}Encoding/Encode?AlgoName={Uri.EscapeDataString(AlgoName)}";

            //2.create the custome http request
            var request = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = JsonContent.Create(new { inputData = encodingData })
            };

            //3.add the authorization header
            request.Headers.Add(_options.Value.ApiHeaderName, _options.Value.ApiKey);

            //4. send the request and get the response
            var response = await _httpClient.SendAsync(request);

            //5. ensure the correct response we get
            response.EnsureSuccessStatusCode();

            //6. read the response content as a string and convert this to ApiResponse
            var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse>();
            return apiResponse ?? new ApiResponse();
        }

        public async Task<IEnumerable<EncodingAlgorithmResponse>> GetEncodingAlgorithmsAsync()
        {
            //1.create the request URL
            string url = $"{_options.Value.ApiBaseUrl}Encoding/Algorithms";

            //2.creawte custome httprequest
            using var httpRequest = new HttpRequestMessage(HttpMethod.Get, url);

            //3.add the authorization header
            httpRequest.Headers.Add(_options.Value.ApiHeaderName,_options.Value.ApiKey);

            //4.send the request and get the response
            var response = await _httpClient.SendAsync(httpRequest);

            //5. ensure the correct repose we get
            response.EnsureSuccessStatusCode();

            //6. read the response content as a string and convert this to the list of EncodingAlgorithmResponse
            var data = await response.Content.ReadFromJsonAsync<IEnumerable<EncodingAlgorithmResponse>>();

            return data ?? Enumerable.Empty<EncodingAlgorithmResponse>();
        }
    }
}
