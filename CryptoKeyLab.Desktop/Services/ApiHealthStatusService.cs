using CryptoKeyLab.Desktop.Models.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CryptoKeyLab.Desktop.Services
{
    public class ApiHealthStatusService
    {
        private readonly HttpClient _httpClient;
        private readonly IOptions<AppSettingModel> _configuration;

        public ApiHealthStatusService(HttpClient httpClient, IOptions<AppSettingModel> configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<bool> CheckApiHealthStatusAsync()
        {
            try
            {
                //1 form base url
                string url = $"{_configuration.Value.ApiBaseUrl}/health";

                // 2. send request to api for new api key
                var response = await _httpClient.GetAsync(url);

                //3.convert respose into apikey model
                if(response.IsSuccessStatusCode)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
