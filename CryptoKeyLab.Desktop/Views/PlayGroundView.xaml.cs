using CryptoKeyLab.Desktop.Services;
using CryptoKeyLab.Desktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CryptoKeyLab.Desktop.Views
{
    /// <summary>
    /// Interaction logic for PlayGroundView.xaml
    /// </summary>
    public partial class PlayGroundView : Window
    {
        public PlayGroundView(PlayGroundViewModel hashAlgorithmService)
        {
            InitializeComponent();
            DataContext = hashAlgorithmService;
        }
    }
}
