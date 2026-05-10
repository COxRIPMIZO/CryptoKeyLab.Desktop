using CryptoKeyLab.Desktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoKeyLab.Desktop.Interfaces
{
    public interface IAuthService
    {
        Task<UserModel> LoginAsync(string userName, string passWord);
    }
}
