using CryptoKeyLab.Desktop.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CryptoKeyLab.Desktop.Models
{
    public class ApiStatusModel : ObservableObject
    {
        private string? _statusMessage;
        private Brush? _statusColor;


        public string? StatusMessage
        {
            get => _statusMessage;
            set
            {
                _statusMessage = value;
                OnPropertyChanged(nameof(StatusMessage));
            }
        }

        public Brush? StatusColor
        {
            get => _statusColor;
            set
            {
                _statusColor = value;
                OnPropertyChanged(nameof(StatusColor));
            }
        }
    }
}
