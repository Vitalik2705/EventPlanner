//using DAL.Data;
//using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using BLL.Services.Interfaces;
using BLL.Services.Repositories;
using DAL.Data;
using Serilog;
using Microsoft.Extensions.Logging;

namespace PresentationUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    /// 




    public partial class App : Application
    {
        public static IHost? AppHost { get; private set; }

        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
                .UseSerilog((host, loggerConfiguration) =>
                {
                    loggerConfiguration.WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
                        .WriteTo.Debug();
                        //.MinimumLevel.Error()
                        //.MinimumLevel.Override("LoggingDemo.Commands", Serilog.Events.LogEventLevel.Debug);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<ILogger<LoginWindow>, Logger<LoginWindow>>();
                    services.AddSingleton<MainWindow>();
                    services.AddTransient<IUserRepository, UserRepository>();
                    services.AddTransient<IUserService, UserService>();
                    //services.AddTransient<IGenericRepository, GenericRepository>();
                    services.AddTransient<IDesignTimeDbContextFactory<EventPlannerContext>, EventPlannerContextFactory>();
                    services.AddTransient<EventPlannerContext>();
                    //services.AddTransient<ILogger<LoginWindow>, Logger<LoginWindow>>();
                    //services.AddTransient<ILogger<RegisterWindow>, Logger<RegisterWindow>>();
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost!.StartAsync();

            var startupForm = AppHost.Services.GetRequiredService<MainWindow>();
            startupForm.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost!.StopAsync();
            base.OnExit(e);
        }


    }







    //public partial class App : Application
    //{
    //    private IServiceProvider _serviceProvider;

    //    protected override void OnStartup(StartupEventArgs e)
    //    {
    //        base.OnStartup(e);

    //        // Set up services and the service provider
    //        var services = new ServiceCollection();
    //        ConfigureServices(services);
    //        _serviceProvider = services.BuildServiceProvider();

    //        // Create and show the main window
    //        var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
    //        mainWindow.Show();
    //    }

    //    private void ConfigureServices(IServiceCollection services)
    //    {
    //        // Register your services here
    //        services.AddSingleton<IUserRepository, UserRepository>();
    //        services.AddSingleton<IUserService, UserService>(); // Example registration
    //        services.AddTransient<MainWindow>();
    //        services.AddSingleton<IDesignTimeDbContextFactory<EventPlannerContext>, EventPlannerContextFactory>();
    //        services.AddSingleton<EventPlannerContext>();  // Example registration
    //        // Add more services as needed
    //    }
    //}
}
