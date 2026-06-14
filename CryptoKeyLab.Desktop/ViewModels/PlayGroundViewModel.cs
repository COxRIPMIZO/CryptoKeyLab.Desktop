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

        public ApiRequest ApiRequest { get; set; } = new ApiRequest();

        // 2. Use ObservableCollection, and make it read-only so the reference never breaks
        public ObservableCollection<HashAlgorithmsResponse> HashAlgorithms { get; } = new ObservableCollection<HashAlgorithmsResponse>();
        public ObservableCollection<EncodingAlgorithmResponse> EncodingAlgorithms { get; } = new ObservableCollection<EncodingAlgorithmResponse>();

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
