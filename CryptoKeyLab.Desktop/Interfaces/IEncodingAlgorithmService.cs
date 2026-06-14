using CryptoKeyLab.Desktop.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoKeyLab.Desktop.Interfaces
{
    public interface IEncodingAlgorithmService
    {
        Task<IEnumerable<EncodingAlgorithmResponse>> GetEncodingAlgorithmsAsync();
    }
}
