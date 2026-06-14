using CryptoKeyLab.Desktop.Helper;
using CryptoKeyLab.Desktop.Interfaces;
using CryptoKeyLab.Desktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CryptoKeyLab.Desktop.ViewModels
{
    public class ApiKeyViewModel : ObservableObject
    {
        private readonly IApiKeyService _apiKeyService;
        
        private ApiKeyModel _apiKey;

        public ApiKeyModel ApiKey
        {
            get => _apiKey;
            set
            {
                _apiKey = value;
                OnPropertyChanged(nameof(ApiKey));            
            }
        }

        public ICommand GetApiKeyCommand { get; private set; }

        public ApiKeyViewModel(IApiKeyService apiKeyService)
        {
            _apiKeyService = apiKeyService;
            GetApiKeyCommand = new RelayCommand<object?>(async _ => await GetApiKeyAsync());
        }

        //get api key from api and set to ApiKey property
        private async Task GetApiKeyAsync()
        {
            ApiKey = await _apiKeyService.GetApiKey();
        }
    }
}
