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
    using DAL.State.Authenticator;
    using Microsoft.Extensions.Logging;
    using PresentationUI.Interfaces;

    /// <summary>
    /// Interaction logic for GuestAddWindow.xaml.
    /// </summary>
    public partial class GuestAddWindow : Window, IGuestAddWindow
    {
        private readonly INavigationService _navigationService;
        private readonly IGuestService _guestService;
        private readonly ILogger<GuestAddWindow> _guestLogger;
        private readonly IAuthenticator _authenticator;


        /// <summary>
        /// Initializes a new instance of the <see cref="GuestAddWindow"/> class.
        /// </summary>
        /// <param name="guestService"></param>
        /// <param name="navigationService"></param>
        /// <param name="guestLogger"></param>
        public GuestAddWindow(IGuestService guestService, INavigationService navigationService, ILogger<GuestAddWindow> guestLogger, IAuthenticator authenticator)
        {
            this._navigationService = navigationService;
            this._guestService = guestService;
            this._guestLogger = guestLogger;
            this._authenticator = authenticator;

            this.InitializeComponent();
        }

        private void Guests_Click(object sender, RoutedEventArgs e)
        {
            this._navigationService.NavigateTo<IGuestListWindow>();
            this.Close();
        }

        private void Events_Click(object sender, RoutedEventArgs e)
        {
            this._navigationService.NavigateTo<IEventListWindow>();
            this.Close();
        }

        private void Recipes_Click(object sender, RoutedEventArgs e)
        {
            this._navigationService.NavigateTo<IRecipeListWindow>();
            this.Close();
        }

        private async void AddGuest_Click(object sender, RoutedEventArgs e)
        {
            this._guestLogger.LogInformation("Attempting to add the guest.");

            var name = this.FirstNameInput.Text;
            var surname = this.LastNameInput.Text;
            var selectedComboBoxItem = (ComboBoxItem)SexInput.SelectedItem;
            string selectedSex = selectedComboBoxItem.Content.ToString();
            var gender = selectedSex != "Чоловік" ? Gender.Female : Gender.Male;
            
            if(string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname))
            {
                ShowErrorMessage("Гість повинен мати не порожнє ім'я та прізвище");
                return;
            }

            Guest guest = new Guest()
            {
                Surname = surname,
                Name = name,
                UserId = this._authenticator.CurrentUser.UserId,
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

        private void ___images_icons8_logout_50_png_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this._authenticator.Logout();

            this._navigationService.NavigateTo<IMainWindow>();
            this.Close();
        }
        private void ShowErrorMessage(string errorMessage)
        {
            // You can implement the logic to display the error message to the user here.
            // For example, show a MessageBox or update a UI element with the error message.
            MessageBox.Show(errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
