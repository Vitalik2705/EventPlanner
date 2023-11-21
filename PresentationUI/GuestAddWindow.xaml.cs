
﻿// <copyright file="GuestAddWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PresentationUI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;
    using BLL.Services.Interfaces;
    using DAL.Models;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Interaction logic for GuestAddWindow.xaml
    /// </summary>
    public partial class GuestAddWindow : Window, IGuestAddWindow
    {
        private readonly INavigationService _navigationService;
        private readonly IGuestService _guestService;
        private readonly ILogger<GuestAddWindow> _guestLogger;

        public GuestAddWindow(IGuestService guestService, INavigationService navigationService, ILogger<GuestAddWindow> guestLogger)
        {

            _navigationService = navigationService;
            _guestService = guestService;
            _guestLogger = guestLogger;

            this.InitializeComponent();
        }

        private void Guests_Click(object sender, RoutedEventArgs e)
        {
            _navigationService.NavigateTo<IGuestListWindow>();
            this.Close();
        }

        private void Events_Click(object sender, RoutedEventArgs e)
        {
            EventListWindow secondWindow = new EventListWindow(_navigationService);
            secondWindow.Show();
            this.Close();
        }

        private void Recipes_Click(object sender, RoutedEventArgs e)
        {
            //RecipeListWindow secondWindow = new RecipeListWindow(_navigationService);
            //secondWindow.Show();
            _navigationService.NavigateTo<IRecipeListWindow>();
            this.Close();
        }

        private async void AddGuest_Click(object sender, RoutedEventArgs e)
        {
            this._guestLogger.LogInformation("Attempting to add the guest.");

            var name = this.FirstNameInput.Text;
            var surname = this.LastNameInput.Text;
            var gender = this.SexInput.SelectedItem != "Чоловік" ? Gender.Female : Gender.Male;

            Guest guest = new Guest()
            {
                Surname = surname,
                Name = name,
                Gender = gender,
            };
            try
            {
                await _guestService.AddGuest(guest);

                this._guestLogger.LogInformation("Successfully added the guest.");

                //AccountWindow secondWindow = new AccountWindow(userReg);

                _navigationService.NavigateTo<IGuestListWindow>();
                this.Close();
            }
            catch (Exception ex)
            {
                this._guestLogger.LogError("Failed to add the guest.");
            }
        }
    }
}
