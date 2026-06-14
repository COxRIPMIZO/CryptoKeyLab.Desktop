using CryptoKeyLab.Desktop.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoKeyLab.Desktop.Models.Response
{
    public class ApiResponse : ObservableObject
    {
        private string? output;
        private decimal timeTakenMilliSeconds;

        public string? Output
        {
            get => output;
            set
            {
                output = value;
                OnPropertyChanged(nameof(Output));
            }
        }
        public decimal TimeTakenMilliSeconds
        {
            get => timeTakenMilliSeconds;
            set
            {
                timeTakenMilliSeconds = value;
                OnPropertyChanged(nameof(TimeTakenMilliSeconds));
            }
        }
    }
}
