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
    public partial class LoginWindow : Window
    {
        private readonly IUserService _userService;
        private readonly ILogger<LoginWindow> _loginLogger;
        private readonly ILogger<RegisterWindow> _registerLogger;


        public LoginWindow(IUserService userService, ILogger<LoginWindow> loginLogger, ILogger<RegisterWindow> registerLogger)
        {
            this._userService = userService;
            this._loginLogger = loginLogger;
            this._registerLogger = registerLogger;
            this.InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow secondWindow = new RegisterWindow(this._userService, this._registerLogger, this._loginLogger);
            secondWindow.Show();
            this.Close();
        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            //this._loginLogger.LogInformation("Attempting to log into the account.");

            var email = this.EmailInput.Text;
            var password = this.PasswordInput.Password;

            try
            {
                var user = await this._userService.Login(password, email);

                //this._loginLogger.LogInformation("Successfully logged into the account.");

                AccountWindow secondWindow = new AccountWindow(user);
                secondWindow.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                //this._loginLogger.LogError($"Failed to log into the account. {ex}");
            }
        }
    }
}
