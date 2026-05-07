using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoKeyLab.Desktop.Helper
{
    public class ObservableObject : INotifyPropertyChanged
    {
        // ReSharper disable once EventNeverSubscribedTo.Global
        public event PropertyChangedEventHandler? PropertyChanged;

        // ReSharper disable once UnusedMember.Global
        public void OnPropertyChanged(string propName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}
