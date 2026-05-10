using CryptoKeyLab.Desktop.Data;
using CryptoKeyLab.Desktop.Interfaces;
using CryptoKeyLab.Desktop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoKeyLab.Desktop.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _appDbContext;

        //inject appdbcontext from di
        public AuthService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<UserModel> LoginAsync(string userName, string passWord)
        {
            //user ef core to search the databse
            //check the firstordefault based on username and password  and if not found it return null
            var users = await _appDbContext.Users.FirstOrDefaultAsync(app => app.UserName == userName && app.Password == passWord);

            return users!;
        }
    }
}
