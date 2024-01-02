﻿// <copyright file="App.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PresentationUI
{
    using System.Windows;
    using BLL.Services.Implementations;
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
                    services.AddTransient<IGenericRepository<Event>, GenericRepository<Event>>();
                    services.AddTransient<IGenericRepository<Recipe>, GenericRepository<Recipe>>();
                    services.AddTransient<IGenericRepository<IngredientUnit>, GenericRepository<IngredientUnit>>();
                    services.AddTransient<IGenericRepository<EventGuest>, GenericRepository<EventGuest>>();
                    services.AddTransient<IGenericRepository<EventRecipe>, GenericRepository<EventRecipe>>();
                    services.AddTransient<IGenericRepository<IngredientUnitRecipe>, GenericRepository<IngredientUnitRecipe>>();
                    services.AddTransient<IGenericRepository<DAL.Models.IngredientNew>, GenericRepository<DAL.Models.IngredientNew>>();

                    services.AddScoped<IUserService, UserService>();
                    services.AddScoped<IGuestService, GuestService>();
                    services.AddScoped<IEventService, EventService>();
                    services.AddScoped<IRecipeService, RecipeService>();
                    services.AddScoped<IEventGuestService, EventGuestService>();
                    services.AddScoped<IEventRecipeService, EventRecipeService>();
                    services.AddScoped<IIngredientUnitService, IngredientUnitService>();
                    services.AddScoped<IAuthenticator, Authenticator>();
                    services.AddSingleton<IUserStore, UserStore>();
                    services.AddScoped<IIngredientUnitRecipeService, IngredientUnitRecipeService>();
                    services.AddScoped<IIngredientNewService, IngredientNewService>();

                    services.AddTransient<IMainWindow, MainWindow>();
                    services.AddTransient<ILoginWindow, LoginWindow>();
                    services.AddTransient<IOpportunitiesWindow, OpportunitiesWindow>();
                    services.AddTransient<IRegisterWindow, RegisterWindow>();
                    services.AddTransient<IGuestListWindow, GuestListWindow>();
                    services.AddTransient<IGuestAddWindow, GuestAddWindow>();
                    services.AddTransient<IAccountWindow, AccountWindow>();
                    services.AddTransient<IRecipeListWindow, RecipeListWindow>();
                    services.AddTransient<IRecipeAddWindow, RecipeAddWindow>();
                    services.AddTransient<IRecipeInfoWindow, RecipeInfoWindow>();
                    services.AddTransient<IEventAddWindow, EventAddWindow>();
                    services.AddTransient<IEventListWindow, EventListWindow>();
                    services.AddTransient<IAboutUsWindow, AboutUsWindow>();
                    services.AddTransient<IChangePasswordWindow, ChangePasswordWindow>();
                    services.AddTransient<IIngredientNew, Ingr>();
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
