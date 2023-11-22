// <copyright file="GuestAddWindow.xaml.cs" company="PlaceholderCompany">
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
    /// Interaction logic for GuestAddWindow.xaml.
    /// </summary>
    public partial class GuestAddWindow : Window, IGuestAddWindow
    {
        private readonly INavigationService _navigationService;
        private readonly IGuestService _guestService;
        private readonly ILogger<GuestAddWindow> _guestLogger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GuestAddWindow"/> class.
        /// </summary>
        /// <param name="guestService"></param>
        /// <param name="navigationService"></param>
        /// <param name="guestLogger"></param>
        public GuestAddWindow(IGuestService guestService, INavigationService navigationService, ILogger<GuestAddWindow> guestLogger)
        {
            this._navigationService = navigationService;
            this._guestService = guestService;
            this._guestLogger = guestLogger;

            this.InitializeComponent();
        }

        private void Guests_Click(object sender, RoutedEventArgs e)
        {
            this._navigationService.NavigateTo<IGuestListWindow>();
            this.Close();
        }

        private void Events_Click(object sender, RoutedEventArgs e)
        {
            EventListWindow secondWindow = new EventListWindow(this._navigationService);
            secondWindow.Show();
            this.Close();
        }

        private void Recipes_Click(object sender, RoutedEventArgs e)
        {
            RecipeListWindow secondWindow = new RecipeListWindow(this._navigationService);
            secondWindow.Show();
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
                await this._guestService.AddGuest(guest);

                this._guestLogger.LogInformation("Successfully added the guest.");

                // AccountWindow secondWindow = new AccountWindow(userReg);
                this._navigationService.NavigateTo<IGuestListWindow>();
                this.Close();
            }
            catch (Exception ex)
            {
                this._guestLogger.LogError($"Failed to add the guest. {ex}");
            }
        }
    }
}
