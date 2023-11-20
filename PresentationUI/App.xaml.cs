namespace PresentationUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    using System.Windows;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using BLL.Services.Interfaces;
    using BLL.Services.Repositories;
    using DAL.Data;
    using Serilog;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.Logging;
    using DAL.Models;

    public partial class App : Application
    {
        public static IHost? AppHost { get; private set; }

        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
                //.UseSerilog((host, loggerConfiguration) =>
                //{
                //    loggerConfiguration.WriteTo.File("C:/Users/bozen/Documents/Програмна інженерія/EventPlanner/PresentationUI/logs/log.txt", rollingInterval: RollingInterval.Day)
                //        .WriteTo.Debug()
                //        .MinimumLevel.Information()
                //        .MinimumLevel.Override("INF", Serilog.Events.LogEventLevel.Information);
                //})
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddTransient<INavigationService, NavigationService>();
                    services.AddSingleton<IDesignTimeDbContextFactory<EventPlannerContext>, EventPlannerContextFactory>();
                    services.AddTransient<EventPlannerContext>();
                    services.AddTransient<IUserRepository, UserRepository>();
                    services.AddTransient<IGenericRepository<Guest>, GenericRepository<Guest>>();
                    services.AddScoped<IUserService, UserService>();
                    services.AddScoped<IGuestService, GuestService>();
                    services.AddTransient<IMainWindow, MainWindow>();
                    services.AddTransient<ILoginWindow, LoginWindow>();
                    services.AddTransient<IRegisterWindow, RegisterWindow>();
                    services.AddTransient<IGuestListWindow, GuestListWindow>();
                    services.AddTransient<IGuestAddWindow, GuestAddWindow>();
                    //services.AddTransient<ILogger<LoginWindow>, Logger<LoginWindow>>();
                    //services.AddTransient<ILogger<RegisterWindow>, Logger<RegisterWindow>>();
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            await AppHost!.StartAsync();

            var startupForm = AppHost.Services.GetRequiredService<IMainWindow>();
            startupForm.Show();

            
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
