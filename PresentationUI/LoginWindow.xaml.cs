// <copyright file="LoginWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PresentationUI
{
    using System;
    using System.Windows;
    using BLL.Services.Interfaces;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Interaction logic for LoginWindow.xaml.
    /// </summary>
    public partial class LoginWindow : Window, ILoginWindow
    {
        private readonly IUserService _userService;
        private readonly INavigationService _navigationService;
        private readonly ILogger<LoginWindow> _loginLogger;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginWindow"/> class.
        /// </summary>
        /// <param name="userService"></param>
        /// <param name="navigationService"></param>
        /// <param name="loginLogger"></param>
        public LoginWindow(IUserService userService, INavigationService navigationService, ILogger<LoginWindow> loginLogger)
        {
            this._navigationService = navigationService;
            this._userService = userService;
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
                var user = await this._userService.Login(password, email);

                this._loginLogger.LogInformation("Successfully logged into the account.");

                AccountWindow secondWindow = new AccountWindow(user, this._navigationService);
                secondWindow.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                this._loginLogger.LogError($"Failed to log into the account.{ex}");
            }
        }
    }
}
