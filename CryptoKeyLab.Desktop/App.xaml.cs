using CryptoKeyLab.Desktop.Data;
using CryptoKeyLab.Desktop.Interfaces;
using CryptoKeyLab.Desktop.Models.Configuration;
using CryptoKeyLab.Desktop.Services;
using CryptoKeyLab.Desktop.ViewModels;
using CryptoKeyLab.Desktop.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Windows;

namespace CryptoKeyLab.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        //// Add this at the top of your file
        //[System.Runtime.InteropServices.DllImport("kernel32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
        //private static extern bool SetDllDirectory(string lpPathName);

        private IHost _host;

        public App()
        {

            //#region Normal running code without dll name change

            //// 1. Tell Windows to look in 'CSPL_OCRLibs' for Native (C++) DLLs
            //string libsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CSPL_OCRLibs");
            //SetDllDirectory(libsFolder);

            //// 2. Tell .NET to look in 'CSPL_OCRLibs' for Managed (C#) DLLs
            //AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            //    {
            //        string assemblyName = new AssemblyName(args.Name).Name + ".dll";
            //        string assemblyPath = Path.Combine(libsFolder, assemblyName);
            //        return File.Exists(assemblyPath) ? Assembly.LoadFrom(assemblyPath) : null;
            //    };

            ////try
            ////{
               
            ////}
            ////catch (Exception ex)
            ////{
            ////    MessageBox.Show(ex.ToString(), "CRASH LOG");
            ////}

            //#endregion


            _host = Host.CreateDefaultBuilder().ConfigureAppConfiguration((context,config) => 
            {
                config.AddJsonFile("Configuration/appsettings.json",optional : false,reloadOnChange : true);

            }).ConfigureServices((context, services) => 
            {
                //configuring the EF
                var connectionString = context.Configuration.GetConnectionString("DefaultConnection");

                services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

                //configure the appsettings.json file
                services.Configure<AppSettingModel>(context.Configuration);

                //register services here
                services.AddTransient<IApiKeyService, ApiKeyService>();

                //injecting the ef for user
                services.AddTransient<IAuthService, AuthService>();

                services.AddTransient<IHashAlgorithmService, HashAlgorithmService>();
                services.AddTransient<IEncodingAlgorithmService, EncodingAlgorithmService>();


                //injecting user registration sercvice

                services.AddTransient<HttpClient>();
                services.AddTransient<ApiHealthStatusService>();
                services.AddTransient<PeriodicTimer>(provider => new PeriodicTimer(TimeSpan.FromSeconds(5)));
                services.AddTransient<CancellationTokenSource>(_ => new CancellationTokenSource());

                //register view models here
                services.AddTransient<ApiKeyViewModel>();
                services.AddTransient<LoginViewModel>();
                services.AddTransient<UserRegistrationViewModel>();
                services.AddTransient<ApiHealthStatusViewModel>();
                services.AddTransient<PlayGroundViewModel>();

                //register views here
                services.AddTransient<LoginView>();
                services.AddTransient<ApiKeyView>();
                services.AddTransient<ApiHealthStatusView>();
                services.AddTransient<MainWindow>();
                services.AddTransient<UserRegistrationView>();


                services.AddTransient<PlayGroundView>();

            }).Build();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override async void OnStartup(StartupEventArgs e)
        {
            //start the host
            await _host.StartAsync();

            //show the main window
            //var mainWindow = _host.Services.GetRequiredService<MainWindow>();

            //var mainWindow = _host.Services.GetRequiredService<LoginView>();
            var mainWindow = _host.Services.GetRequiredService<PlayGroundView>();
            //var mainWindow = _host.Services.GetRequiredService<UserRegistrationView>();

            //display window
            mainWindow.Show();

            //call base method
            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            //stop the host
            await _host.StopAsync();

            //dispose the host
            _host.Dispose();

            //call base method
            base.OnExit(e);
        }
    }

}
