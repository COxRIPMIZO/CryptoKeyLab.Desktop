using CryptoKeyLab.Desktop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoKeyLab.Desktop.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) 
        //{
        //    dbContextOptionsBuilder.UseSqlServer();
        //}

        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
    }
}
