using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RunList.ModelViews;
using RunList.Servises;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace RunList
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Window ActivetWindow => Application.Current.Windows.OfType<Window>()
          .FirstOrDefault(w => w.IsActive);
        public static Window FocusWindow => Application.Current.Windows.OfType<Window>()
            .FirstOrDefault(w => w.IsFocused);
        public static Window CurrentWindow => FocusWindow ?? ActivetWindow;
        private static IHost _host;
        public static IHost Host => _host
            ??= Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        public static IServiceProvider Services => Host.Services;

        internal static void ConfigureServices(HostBuilderContext host, IServiceCollection services) => services
         .AddServices()
         .AddViewModel();

        protected override async void OnStartup(StartupEventArgs e)
        {
            var host = Host;
            base.OnStartup(e);
            await host.StartAsync();
        }
        protected override async void OnExit(ExitEventArgs e)
        {
            using var host = Host;
            base.OnExit(e);
            await host.StopAsync();
        }


    }
}
