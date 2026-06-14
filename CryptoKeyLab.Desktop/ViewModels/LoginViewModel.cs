using CryptoKeyLab.Desktop.Helper;
using CryptoKeyLab.Desktop.Interfaces;
using CryptoKeyLab.Desktop.Models;
using CryptoKeyLab.Desktop.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace CryptoKeyLab.Desktop.ViewModels
{
    public class LoginViewModel : ObservableObject
    {
        private readonly IAuthService _authService;

        private readonly IServiceProvider _servicesProvider;
        public UserModel UserModel { get; set; }


        private string? _result = string.Empty;
        public string? Result 
        { get => _result; 
          set
            {
                _result = value;
                OnPropertyChanged(nameof(Result));
            }                                                                                                           
        }

        private Brush _resultColor = Brushes.Red;
        public Brush ResultColor
        {
            get => _resultColor;
            set
            {
                _resultColor = value;
                OnPropertyChanged(nameof(ResultColor));
            }
        }

        public ICommand AuthenticateLogin { get; private set; }
        public ICommand OpenRegistrationWindowCommand { get; private set; }
        public LoginViewModel(IAuthService authService, IServiceProvider serviceProvider)
        {
            UserModel = new UserModel();
            _authService = authService;
            _servicesProvider = serviceProvider;
            AuthenticateLogin = new RelayCommand<object>(async _ => await AuthUser());
            OpenRegistrationWindowCommand = new RelayCommand<object>(_ => OpenRegistrationWindow());
        }

        private async Task AuthUser()
        {
            var user = await _authService.LoginAsync(UserModel.UserName,UserModel.Password);

            //check result
            Result = user is null ? "User not found or wrong credential." : string.Empty;

            ResultColor = user is null ? Brushes.Red : Brushes.Green;
        }

        private void OpenRegistrationWindow() 
        {
            UserRegistrationView userRegistrationView = _servicesProvider.GetRequiredService<UserRegistrationView>();

            userRegistrationView.ShowDialog();
        }
    }
}
