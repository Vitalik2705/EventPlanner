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

            try
            {
                var user = await this._authenticator.Login(password, email);

                this._loginLogger.LogInformation("Successfully logged into the account.");

                this._navigationService.NavigateTo<IAccountWindow>();

                this.Close();
            }
            catch (Exception ex)
            {
                this._loginLogger.LogError($"Failed to log into the account. {ex}");
            }
        }
    }
}
