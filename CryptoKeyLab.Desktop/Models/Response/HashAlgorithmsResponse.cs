using CryptoKeyLab.Desktop.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoKeyLab.Desktop.Models.Response
{
    public class HashAlgorithmsResponse : ObservableObject
    {
        private string? name;
        private string? algoFamily;
        private bool requiresSalt;
        private bool requiredKey;
        private bool requiredIteration;
        private bool isSecure;
        private bool isActive;


        public string? Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string? AlgorithmFamily
        {
            get => algoFamily;
            set
            {
                algoFamily = value;
                OnPropertyChanged(nameof(AlgorithmFamily));
            }
        }

        public bool IsSecure
        {
            get => isSecure;
            set
            {
                isSecure = value;
                OnPropertyChanged(nameof(IsSecure));
            }
        }

        public bool IsActive
        {
            get => isActive;
            set
            {
                isActive = value;
                OnPropertyChanged(nameof(IsActive));
            }
        }

        public bool RequiresSalt
        {
            get => requiresSalt;
            set
            {
                requiresSalt = value;
                OnPropertyChanged(nameof(RequiresSalt));
            }
        }

        public bool RequiresKey
        {
            get => requiredKey;
            set
            {
                requiredKey = value;
                OnPropertyChanged(nameof(RequiresKey));
            }
        }

        public bool RequiresIteration
        {
            get => requiredIteration;
            set
            {
                requiredIteration = value;
                OnPropertyChanged(nameof(RequiresIteration));
            }
        }
    }
}
