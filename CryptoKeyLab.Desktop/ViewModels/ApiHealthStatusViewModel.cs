//using CryptoKeyLab.Desktop.Models;
//using CryptoKeyLab.Desktop.Services;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Net.NetworkInformation;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Media;

//namespace CryptoKeyLab.Desktop.ViewModels
//{
//    public class ApiHealthStatusViewModel : IDisposable
//    {
//        public ApiStatusModel ApiStatusModel { get; init; } = new();

//        private readonly ApiHealthStatusService _apiHealthStatusService;
//        private readonly PeriodicTimer _timer;
//        private readonly CancellationTokenSource _cts;

//        public ApiHealthStatusViewModel(ApiHealthStatusService apiHealthStatusService, PeriodicTimer timer, CancellationTokenSource cancellationTokenSource)
//        {
//            _apiHealthStatusService = apiHealthStatusService;
//            _timer = timer;
//            _cts = cancellationTokenSource;

//            //intialize the api status model
//            ApiStatusModel.StatusMessage = "Checking API status...";
//            ApiStatusModel.StatusColor = System.Windows.Media.Brushes.Gray;
//        }

//        private async Task MonitorApiHealthStatusAsync(CancellationToken cancellationToken)
//        {
//            await CheckApiHealthStatusAsync();

//            try
//            {
//                while (await _timer.WaitForNextTickAsync(cancellationToken))
//                {
//                    await CheckApiHealthStatusAsync();
//                }
//            }
//            catch (OperationCanceledException)
//            {
//                // Handle the cancellation gracefully
//            }
//        }

//        private async Task CheckApiHealthStatusAsync()
//        {
//            try
//            {
//                bool isApiHealthy = await _apiHealthStatusService.CheckApiHealthStatusAsync();
//                if (isApiHealthy)
//                {
//                    ApiStatusModel.StatusMessage = "API is healthy";
//                    ApiStatusModel.StatusColor = System.Windows.Media.Brushes.Green;
//                }
//                else
//                {
//                    ApiStatusModel.StatusMessage = "API is not healthy";
//                    ApiStatusModel.StatusColor = System.Windows.Media.Brushes.Red;
//                }
//            }
//            catch (Exception)
//            {
//                ApiStatusModel.StatusMessage = "API Offline";
//                ApiStatusModel.StatusColor = Brushes.Red;
//            }
//        }

//        public void Dispose()
//        {
//            _timer.Dispose();
//            GC.SuppressFinalize(this);
//        }
//    }
//}



using CryptoKeyLab.Desktop.Helper;
using CryptoKeyLab.Desktop.Models;
using CryptoKeyLab.Desktop.Services;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CryptoKeyLab.Desktop.ViewModels
{
    public class ApiHealthStatusViewModel : ObservableObject, IDisposable
    {
        private ApiStatusModel _apiStatus = new();

        public ApiStatusModel ApiStatus
        {
            get => _apiStatus;
            set
            {
                _apiStatus = value;
                OnPropertyChanged(nameof(ApiStatus));
            }
        }

        private readonly ApiHealthStatusService _apiHealthStatusService;
        private readonly PeriodicTimer _timer;
        private readonly CancellationTokenSource _cts;

        public ApiHealthStatusViewModel(ApiHealthStatusService apiHealthStatusService, PeriodicTimer timer, CancellationTokenSource cancellationTokenSource)
        {
            _apiHealthStatusService = apiHealthStatusService;
            _timer = timer;
            _cts = cancellationTokenSource;

            ApiStatus.StatusMessage = "Checking API status...";
            ApiStatus.StatusColor = Brushes.Gray;

            // Start monitoring
            _ = MonitorApiHealthStatusAsync(_cts.Token);
        }

        private async Task MonitorApiHealthStatusAsync(CancellationToken cancellationToken)
        {
            await CheckApiHealthStatusAsync();

            try
            {
                while (await _timer.WaitForNextTickAsync(cancellationToken))
                {
                    await CheckApiHealthStatusAsync();
                }
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation gracefully
            }
        }

        private async Task CheckApiHealthStatusAsync()
        {
            try
            {
                bool isApiHealthy = await _apiHealthStatusService.CheckApiHealthStatusAsync();
                if (isApiHealthy)
                {
                    ApiStatus.StatusMessage = "API is healthy";
                    ApiStatus.StatusColor = Brushes.Green;
                }
                else
                {
                    ApiStatus.StatusMessage = "API is unhealthy";
                    ApiStatus.StatusColor = Brushes.Red;
                }
            }
            catch (Exception)
            {
                ApiStatus.StatusMessage = "API check failed";
                ApiStatus.StatusColor = Brushes.Orange;
            }
        }

        public void Dispose()
        {
            _timer?.Dispose();
            _cts?.Dispose();
        }
    }
}
