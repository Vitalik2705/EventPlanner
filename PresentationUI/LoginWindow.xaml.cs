using DAL.Data;
using DAL.Models;
using BLL.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using BLL.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace PresentationUI
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly IUserService _userService;
        private readonly ILogger<LoginWindow> _loginLogger;
        private readonly ILogger<RegisterWindow> _registerLogger;
        public LoginWindow(IUserService userService, ILogger<LoginWindow> loginLogger, ILogger<RegisterWindow> registerLogger)
        {
            _userService = userService;
            _loginLogger = loginLogger;
            _registerLogger = registerLogger;
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow secondWindow = new RegisterWindow(_userService, _registerLogger, _loginLogger);
            secondWindow.Show();
            this.Close();
        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            _loginLogger.LogInformation("Attempting to log into the account.");

            var email = EmailInput.Text;
            var password = PasswordInput.Password;

            try
            {
                var user = await _userService.Login(password, email);

                _loginLogger.LogInformation("Successfully logged into the account.");

                AccountWindow secondWindow = new AccountWindow(user);
                secondWindow.Show();
                this.Close();
            }

            catch (Exception ex)
            {
                _loginLogger.LogError("Failed to log into the account.");
            }
        }
    }
}
