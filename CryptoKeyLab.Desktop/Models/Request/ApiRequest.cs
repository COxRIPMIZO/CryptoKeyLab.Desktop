using CryptoKeyLab.Desktop.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace CryptoKeyLab.Desktop.Models.Request
{
    public class ApiRequest : ObservableObject
    {
        //private string? plaintText;
        private string? AlgorithmName;
        private HashOptionsModel hashOptionsModel;

        //public string? PlaintText
        //{
        //    get => plaintText;
        //    set
        //    {
        //        plaintText = value;
        //        OnPropertyChanged(nameof(PlaintText));
        //    }
        //}
        public string? Algorithm
        {
            get => AlgorithmName;
            set
            {
                AlgorithmName = value;
                OnPropertyChanged(nameof(Algorithm));
            }
        }
        public HashOptionsModel HashOptions
        {
            get => hashOptionsModel;
            set
            {
                hashOptionsModel = value;
                OnPropertyChanged(nameof(HashOptions));
            }
        }
    }
}
