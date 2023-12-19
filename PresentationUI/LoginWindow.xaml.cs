// <copyright file="LoginWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PresentationUI
{
    using System;
    using System.Windows;
    using DAL.State.Authenticator;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Interaction logic for LoginWindow.xaml.
    /// </summary>
    public partial class LoginWindow : Window, ILoginWindow
    {
        private readonly IAuthenticator _authenticator;
        private readonly INavigationService _navigationService;
        private readonly ILogger<LoginWindow> _loginLogger;

        public LoginWindow(IAuthenticator authenticator, INavigationService navigationService, ILogger<LoginWindow> loginLogger)
        {
            this._navigationService = navigationService;
            this._authenticator = authenticator;
            this._loginLogger = loginLogger;
            this.InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            this._navigationService.NavigateTo<IRegisterWindow>();
            this.Close();
        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            this._loginLogger.LogInformation("Attempting to log into the account.");

            var email = this.EmailInput.Text;
            var password = this.PasswordInput.Password;

            // Check if email and password fields are empty
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                // Show an error message indicating that both fields are required
                ShowErrorMessage("Email and password are required");
                return;
            }

            try
            {
                var user = await this._authenticator.Login(password, email);

                // Check if the authentication was successful (customize based on your authentication logic)
                if (user != false)
                {
                    this._loginLogger.LogInformation("Successfully logged into the account.");

                    this._navigationService.NavigateTo<IAccountWindow>();

                    this.Close();
                }
                else
                {
                    // Show an error message indicating authentication failure
                    ShowErrorMessage("Either password or email incorrect. Please try again.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception details
                this._loginLogger.LogError($"Failed to log into the account. {ex.Message}");

                // Show a generic error message to the user
                ShowErrorMessage("An error occurred. Please try again later.");
            }
        }

        private void ShowErrorMessage(string errorMessage)
        {
            // You can implement the logic to display the error message to the user here.
            // For example, show a MessageBox or update a UI element with the error message.
            MessageBox.Show(errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
