using CryptoKeyLab.Desktop.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoKeyLab.Desktop.Models.Request
{
    public class HashOptionsModel : ObservableObject
    {
        private string? input;
        private string? key;
        private string? salt;
        private int iteration;

        public string? Input
        {
            get => input;
            set
            {
                input = value;
                OnPropertyChanged(nameof(Input));
            }
        }
        public string? Key
        {
            get => key;
            set
            {
                key = value;
                OnPropertyChanged(nameof(Key));
            }
        }
        public string? Salt
        {
            get => salt;
            set
            {
                salt = value;
                OnPropertyChanged(nameof(Salt));
            }
        }
        public int Iteration
        {
            get => iteration;
            set
            {
                iteration = value;
                OnPropertyChanged(nameof(Iteration));
            }
        }
    }
}
