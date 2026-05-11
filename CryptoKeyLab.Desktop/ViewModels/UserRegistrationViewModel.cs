using CryptoKeyLab.Desktop.Helper;
using CryptoKeyLab.Desktop.Interfaces;
using CryptoKeyLab.Desktop.Models;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        public ICommand CloseWindowCommand { get; set; }

        public UserRegistrationViewModel(IAuthService service,IApiKeyService apiKeyService)
        {
            UserModel = new UserModel();
            _authService = service;
            _apiKeyService = apiKeyService;

            //create new command
            RegisterUserCommand = new RelayCommand<object>(async parama => await AddNewUser(parama));
            CloseWindowCommand = new RelayCommand<object>(param => CloseWindow(param));
        }

        private void CloseWindow(object param)
        {
            // Implement logic to close the window, e.g., using an event or a messaging system
            if (param is Window window)
                window.Close();
        }

        /// <summary>
        /// Add new user to database and get new apikey
        /// </summary>
        /// <returns></returns>
        private async Task AddNewUser(object param)
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

                await Task.Delay(2000);

                //close the window
                CloseWindow(param);
            }
            else
            {
                Result = "User registration failed.";
                ResultColor = Brushes.Red;
            }
        }
    }
}
