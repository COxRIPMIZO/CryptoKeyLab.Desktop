using CryptoKeyLab.Desktop.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CryptoKeyLab.Desktop.Models
{
    public class ApiKeyModel :ObservableObject
    {
        private string _apiKey = string.Empty;
        private DateTime _dateTime;
        private int _usageCount = 0;
        private string _message = string.Empty;
        private int _rateLimitPerMinute = 0;

        public string ApiKey
        {
            get => _apiKey;
            set
            {
                _apiKey = value;
                OnPropertyChanged(nameof(ApiKey));
            }
        }

        public DateTime ExpireAt
        {
            get => _dateTime;
            set
            {
                _dateTime = value;
                OnPropertyChanged(nameof(DateTime));
            }
        }

        public int UsageCount
        {
            get => _usageCount;
            set 
            {
                _usageCount = value;
                OnPropertyChanged(nameof(UsageCount));
            }
        }

        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        public int RateLimitPerMinute
        {
            get => _rateLimitPerMinute;
            set
            {
                _rateLimitPerMinute = value;
                OnPropertyChanged(nameof(RateLimitPerMinute));
            }
        }
    };
}
