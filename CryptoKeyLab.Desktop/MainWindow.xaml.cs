using CryptoKeyLab.Desktop.Services;
using CryptoKeyLab.Desktop.ViewModels;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CryptoKeyLab.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(ApiKeyViewModel apiKeyViewModel)
        {
            InitializeComponent();

            DataContext = apiKeyViewModel;
        }

        private async void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            //ApiKeyService apiKeyService = new ApiKeyService(null);

            //var apiKey = await apiKeyService.GetApiKey();

            //MessageBox.Show($"API Key: {apiKey.ApiKey}\nDateTime: {apiKey.DateTime}\nUsageCount: {apiKey.UsageCount}\nMessage: {apiKey.Message}\nRateLimitPerMinute: {apiKey.RateLimitPerMinute}");
        }
    }
}