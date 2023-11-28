// <copyright file="App.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PresentationUI
{
    using System.Windows;
    using BLL.Services.Interfaces;
    using BLL.Services.Repositories;
    using BLL.Services.State.Authenticator;
    using BLL.Services.State.Users;
    using DAL.Data;
    using DAL.Models;
    using DAL.State.Authenticator;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using PresentationUI.Interfaces;
    using Serilog;

    /// <summary>
    /// Interaction logic for App.xaml.
    /// </summary>
    public partial class App : Application
    {
        public static IHost? AppHost { get; private set; }

        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
                .UseSerilog((host, loggerConfiguration) =>
                {
                    loggerConfiguration.WriteTo.File("C:/Users/bozen/Documents/Програмна інженерія/EventPlanner/PresentationUI/logs/log.txt", rollingInterval: RollingInterval.Day)
                        .WriteTo.Debug();
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddTransient<INavigationService, NavigationService>();
                    services.AddSingleton<IDesignTimeDbContextFactory<EventPlannerContext>, EventPlannerContextFactory>();
                    services.AddTransient<EventPlannerContext>();

                    services.AddTransient<IUserRepository, UserRepository>();
                    services.AddTransient<IGenericRepository<Guest>, GenericRepository<Guest>>();
                    services.AddTransient<IGenericRepository<Event>, GenericRepository<Event>>();
                    services.AddTransient<IGenericRepository<Recipe>, GenericRepository<Recipe>>();
                    services.AddTransient<IGenericRepository<IngredientUnit>, GenericRepository<IngredientUnit>>();

                    services.AddScoped<IUserService, UserService>();
                    services.AddScoped<IGuestService, GuestService>();
                    services.AddScoped<IEventService, EventService>();
                    services.AddScoped<IRecipeService, RecipeService>();
                    services.AddScoped<IIngredientUnitService, IngredientUnitService>();
                    services.AddScoped<IAuthenticator, Authenticator>();
                    services.AddSingleton<IUserStore, UserStore>();

                    services.AddTransient<IMainWindow, MainWindow>();
                    services.AddTransient<ILoginWindow, LoginWindow>();
                    services.AddTransient<IRegisterWindow, RegisterWindow>();
                    services.AddTransient<IGuestListWindow, GuestListWindow>();
                    services.AddTransient<IGuestAddWindow, GuestAddWindow>();
                    services.AddTransient<IAccountWindow, AccountWindow>();
                    services.AddTransient<IRecipeListWindow, RecipeListWindow>();
                    services.AddTransient<IRecipeAddWindow, RecipeAddWindow>();
                    services.AddTransient<IRecipeInfoWindow, RecipeInfoWindow>();
                    services.AddTransient<IEventAddWindow, EventAddWindow>();
                    services.AddTransient<IEventListWindow, EventListWindow>();
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
}
