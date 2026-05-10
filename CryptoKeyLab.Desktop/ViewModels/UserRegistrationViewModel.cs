using CryptoKeyLab.Desktop.Helper;
using CryptoKeyLab.Desktop.Interfaces;
using CryptoKeyLab.Desktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace CryptoKeyLab.Desktop.ViewModels
{
    public class UserRegistrationViewModel : ObservableObject
    {
        /// <summary>
        /// For user registartion
        /// </summary>
        private readonly IAuthService _authService;

        /// <summary>
        /// for getting new apiKey
        /// </summary>
        private readonly IApiKeyService _apiKeyService;

        private string? _result;
        private Brush _resultColor;

        public string? Result
        {
            get => _result;
            set
            {
                _result = value;
                OnPropertyChanged(nameof(Result));
            }
        }
        public Brush ResultColor
        {
            get => _resultColor;
            set
            {
                _resultColor = value;
                OnPropertyChanged(nameof(ResultColor));
            }
        }

        /// <summary>
        /// Holde user data
        /// </summary>
        public UserModel UserModel { get; set; }
        
        /// <summary>
        /// Command for new user registration
        /// </summary>
        public ICommand RegisterUserCommand { get; set; }

        public UserRegistrationViewModel(IAuthService service,IApiKeyService apiKeyService)
        {
            UserModel = new UserModel();
            _authService = service;
            _apiKeyService = apiKeyService;

            //create new command
            RegisterUserCommand = new RelayCommand<object>(async _ => await AddNewUser());
        }

        private async Task AddNewUser()
        {
            //get brand new api key
            var apiKey = await _apiKeyService.GetApiKey();

            if(apiKey is null)
            {
                Result = "ApiKey Not Generated.";
                ResultColor = Brushes.Red;
                return;
            }

            //register new user 
            UserModel.ApiKey = apiKey.ApiKey;

           bool isRegistrationComplete = await _authService.AddNewUser(UserModel);

            if (isRegistrationComplete)
            { 
                Result = "User registration completed.";
                ResultColor = Brushes.Green;
            }
            else
            {
                Result = "User registration failed.";
                ResultColor = Brushes.Red;
            }
        }
    }
}
