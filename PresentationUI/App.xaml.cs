﻿// <copyright file="App.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PresentationUI
{
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
    using DAL.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
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
                    loggerConfiguration.WriteTo.File("C:/Users/Юля/source/repos/EventPlanner/EventPlanner/PresentationUI/logs/log.txt", rollingInterval: RollingInterval.Day)
                        .WriteTo.Debug();
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddTransient<INavigationService, NavigationService>();
                    services.AddSingleton<IDesignTimeDbContextFactory<EventPlannerContext>, EventPlannerContextFactory>();
                    services.AddTransient<EventPlannerContext>();
                    services.AddTransient<IUserRepository, UserRepository>();
                    services.AddTransient<IGenericRepository<Guest>, GenericRepository<Guest>>();
                    services.AddTransient<IGenericRepository<Recipe>, GenericRepository<Recipe>>();
                    services.AddScoped<IUserService, UserService>();
                    services.AddScoped<IGuestService, GuestService>();
                    services.AddScoped<IRecipeService, RecipeService>();
                    services.AddTransient<IMainWindow, MainWindow>();
                    services.AddTransient<ILoginWindow, LoginWindow>();
                    services.AddTransient<IRegisterWindow, RegisterWindow>();
                    services.AddTransient<IGuestListWindow, GuestListWindow>();
                    services.AddTransient<IGuestAddWindow, GuestAddWindow>();
                    services.AddTransient<IAccountWindow, AccountWindow>();
                    services.AddTransient<IRecipeListWindow, RecipeListWindow>();
                    //services.AddTransient<User>();
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
}
