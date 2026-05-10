using CryptoKeyLab.Desktop.Interfaces;
using CryptoKeyLab.Desktop.Models;
using CryptoKeyLab.Desktop.Models.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CryptoKeyLab.Desktop.Services
{
    public class ApiKeyService : IApiKeyService
    {
        private readonly IOptions<AppSettingModel> _configuration;
        public ApiKeyService(IOptions<AppSettingModel> configuration)
        {
            _configuration = configuration;
        }

        public async Task<ApiKeyModel> GetApiKey()
        {
            using (HttpClient client = new HttpClient())
            {
                //1 form base url
                string url = $"{_configuration.Value.ApiBaseUrl}Access/GenerateTemporaryKey";

                // 2. send request to api for new api key
                var response = await client.PostAsync(url, null);

                //3.convert respose into apikey model
                if (!response.IsSuccessStatusCode)
                {
                    return new ApiKeyModel
                    {
                        Message = $"Error: {response.StatusCode}"
                    };
                }

                HttpContent content = response.Content;
                return await content.ReadFromJsonAsync<ApiKeyModel>();
            }
        }
    }
}
