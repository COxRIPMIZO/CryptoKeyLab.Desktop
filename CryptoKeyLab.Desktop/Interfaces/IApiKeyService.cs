using CryptoKeyLab.Desktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoKeyLab.Desktop.Interfaces
{
    public interface IApiKeyService
    {
        Task<ApiKeyModel> GetApiKey();
    }
}
