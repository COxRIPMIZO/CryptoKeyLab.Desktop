using CryptoKeyLab.Desktop.Models.Request;
using CryptoKeyLab.Desktop.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace CryptoKeyLab.Desktop.Interfaces
{
    public interface IEncodingAlgorithmService
    {
        Task<IEnumerable<EncodingAlgorithmResponse>> GetEncodingAlgorithmsAsync();
        Task<ApiResponse> ComputeEncodingAsync(string AlgoName, string encodingData);
    }
}
