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
        /// <summary>
        /// Validating user
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        Task<UserModel> LoginAsync(string userName, string passWord);

        /// <summary>
        /// Add new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<bool> AddNewUser(UserModel user);
    }
}
