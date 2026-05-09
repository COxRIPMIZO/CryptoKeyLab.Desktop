using CryptoKeyLab.Desktop.Interfaces;
using CryptoKeyLab.Desktop.Services;
using CryptoKeyLab.Desktop.ViewModels;
using CryptoKeyLab.Desktop.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Data;
using System.Windows;

namespace CryptoKeyLab.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder().ConfigureServices((context, services) => 
            {
                //register services here
                services.AddTransient<IApiKeyService, ApiKeyService>();

                //register view models here
                services.AddTransient<ApiKeyViewModel>();

                //register views here
                services.AddTransient<ApiKeyView>();
                services.AddTransient<MainWindow>();

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
            var mainWindow = _host.Services.GetRequiredService<MainWindow>();

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
