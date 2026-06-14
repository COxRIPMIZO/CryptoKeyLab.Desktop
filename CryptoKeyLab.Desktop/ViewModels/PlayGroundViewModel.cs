using CryptoKeyLab.Desktop.Helper;
using CryptoKeyLab.Desktop.Interfaces;
using CryptoKeyLab.Desktop.Models.Request;
using CryptoKeyLab.Desktop.Models.Response;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CryptoKeyLab.Desktop.ViewModels
{
    public class PlayGroundViewModel : ObservableObject
    {
        private readonly IHashAlgorithmService _hashAlgorithmService;
        private HashAlgorithmsResponse _selectedHashAlgo;

        private readonly IEncodingAlgorithmService _encodingAlgorithmService;
        private EncodingAlgorithmResponse _selectedEncodingAlgo;

        public ApiRequest ApiRequest { get; set; } = new();
        private ApiResponse apiReponseHashing = new();
        private ApiResponse apiReponseEncoding = new();
        private string encodingInput { get; set; } = "Enter text to encode or decode...";

        public string EncodingInput
        {
            get => encodingInput;
            set
            {
                encodingInput = value;
                OnPropertyChanged(nameof(EncodingInput));
            }
        }

        public ApiResponse ApiResponseHashing
        {
            get => apiReponseHashing;
            set
            {
                apiReponseHashing = value;
                OnPropertyChanged(nameof(ApiResponseHashing));
            }
        }
        public ApiResponse ApiResponseEncoding
        {
            get => apiReponseEncoding;
            set
            {
                apiReponseEncoding = value;
                OnPropertyChanged(nameof(ApiResponseEncoding));
            }
        }

        // 2. Use ObservableCollection, and make it read-only so the reference never breaks
        public ObservableCollection<HashAlgorithmsResponse> HashAlgorithms { get; } = new();
        public ObservableCollection<EncodingAlgorithmResponse> EncodingAlgorithms { get; } = new();

        //command for hasing algorithms
        public ICommand ComputHashAlgorithmCommand { get; private set; }
        public ICommand ComputEncodingAlgorithmCommand { get; private set; }

        private async Task ComputeEncodingAlgoAsync()
        {
            //1.validation
            if(SelectedEncodingAlgo is null)
            {
                ApiResponseEncoding.Output = "Please select an encoding algorithm.";
                return;
            }

            //2.inout validation
            if (string.IsNullOrWhiteSpace(EncodingInput))
            {
                ApiResponseEncoding.Output = "Please enter some text to encode.";
                return;
            }

            //3.ui feedback
            ApiResponseEncoding.Output = "⏳ Processing calculations on secure server...";

            //4.api call
            try
            {
                var encodingData = await _encodingAlgorithmService.ComputeEncodingAsync(SelectedEncodingAlgo.Name,EncodingInput);

                ApiResponseEncoding = encodingData;
            }
            catch (Exception ex)
            {
                // Show errors (e.g. 500 server error, network down)
                ApiResponseEncoding.Output = $"❌ SYSTEM ERROR: {ex.Message}";
            }
        } 

        private async Task ComputeHashAlgoAsync()
        {
            ///1. validation
            if(SelectedHashAlgo is null)
            {
                ApiResponseHashing.Output = "Please select a hash algorithm.";
                return;
            }

            //2.input validation
            if (string.IsNullOrWhiteSpace(ApiRequest.PlaintText))
            {
                ApiResponseHashing.Output = "Please enter some text to hash.";
                return;
            }

            //3. ui feedback
            ApiResponseHashing.Output = "⏳ Processing calculations on secure server...";

            //4.api call
            try
            {
                ApiRequest.HashOptions.Input = ApiRequest.PlaintText;
                var computedHash = await _hashAlgorithmService.ComputeHashAsync(SelectedHashAlgo.Name, ApiRequest.HashOptions);

                ApiResponseHashing = computedHash;
            }
            catch (Exception ex)
            {
                // Show errors (e.g. 500 server error, network down)
                ApiResponseHashing.Output = $"❌ SYSTEM ERROR: {ex.Message}";
            }
        }

        // 3. Property to hold the user's selection
        public HashAlgorithmsResponse SelectedHashAlgo
        {
            get => _selectedHashAlgo;
            set
            {
                _selectedHashAlgo = value;
                OnPropertyChanged(nameof(SelectedHashAlgo));
            }
        }
        public EncodingAlgorithmResponse SelectedEncodingAlgo
        {
            get => _selectedEncodingAlgo;
            set
            {
                _selectedEncodingAlgo = value;
                OnPropertyChanged(nameof(SelectedEncodingAlgo));
            }
        }

        public PlayGroundViewModel(IHashAlgorithmService hashAlgorithmService,IEncodingAlgorithmService encodingAlgorithmService)
        {
            _hashAlgorithmService = hashAlgorithmService;
            _encodingAlgorithmService = encodingAlgorithmService;

            // 4. Fire and forget is okay here, but wrap in a try-catch inside the method!
            _ = LoadHashAlgorithmsAsync();
            _ = LoadEncodingAlgorithmsAsync();

            //commands
            ComputHashAlgorithmCommand = new RelayCommand<object>(async _ => await ComputeHashAlgoAsync());
            ComputEncodingAlgorithmCommand = new RelayCommand<object>(async _ => await ComputeEncodingAlgoAsync());
        }

        private async Task LoadHashAlgorithmsAsync()
        {
            try
            {
                var algorithms = await _hashAlgorithmService.GetHashAlgorithmsAsync();

                // 5. Do not overwrite the collection. Instead, clear and add to it.
                HashAlgorithms.Clear();
                foreach (var algo in algorithms)
                {
                    HashAlgorithms.Add(algo);
                }

                // Optional: Automatically select the first algorithm in the dropdown
                if (HashAlgorithms.Any())
                {
                    SelectedHashAlgo = HashAlgorithms.First();
                }
            }
            catch (Exception ex)
            {
                // TODO: Handle exceptions (e.g., show an error message if API is down)
                Console.WriteLine($"Failed to load algorithms: {ex.Message}");
            }
        }

        private async Task LoadEncodingAlgorithmsAsync()
        {
            try
            {
                var algorithms = await _encodingAlgorithmService.GetEncodingAlgorithmsAsync();

                // 5. Do not overwrite the collection. Instead, clear and add to it.
                EncodingAlgorithms.Clear();
                foreach (var algo in algorithms)
                {
                    EncodingAlgorithms.Add(algo);
                }

                // Optional: Automatically select the first algorithm in the dropdown
                if (EncodingAlgorithms.Any())
                {
                    SelectedEncodingAlgo = EncodingAlgorithms.First();
                }
            }
            catch (Exception ex)
            {
                // TODO: Handle exceptions (e.g., show an error message if API is down)
                Console.WriteLine($"Failed to load algorithms: {ex.Message}");
            }
        }
    }
}
