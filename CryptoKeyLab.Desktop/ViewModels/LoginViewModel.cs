using CryptoKeyLab.Desktop.Helper;
using CryptoKeyLab.Desktop.Interfaces;
using CryptoKeyLab.Desktop.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace CryptoKeyLab.Desktop.ViewModels
{
    public class LoginViewModel : ObservableObject
    {
        private readonly IAuthService _authService;
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

        public LoginViewModel(IAuthService authService)
        {
            UserModel = new UserModel();
            _authService = authService;
            AuthenticateLogin = new RelayCommand<object>(async _ => await AuthUser());
        }

        private async Task AuthUser()
        {
            var user = await _authService.LoginAsync(UserModel.UserName,UserModel.Password);

            //check result
            Result = user is null ? "User not found or wrong credential." : string.Empty;

            ResultColor = user is null ? Brushes.Red : Brushes.Green;
        }
    }
}
