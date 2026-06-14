using CryptoKeyLab.Desktop.Models.Request;
using CryptoKeyLab.Desktop.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoKeyLab.Desktop.Interfaces
{
    public interface IHashAlgorithmService
    {
        Task<IEnumerable<HashAlgorithmsResponse>> GetHashAlgorithmsAsync();
        Task<ApiResponse> ComputeHashAsync(string AlgoName, HashOptionsModel hashOptionsModel);
    }
}
