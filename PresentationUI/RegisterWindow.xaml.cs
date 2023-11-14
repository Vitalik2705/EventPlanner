using BLL.Services.Interfaces;
using DAL.Models;
using Microsoft.Extensions.Logging;
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

namespace PresentationUI
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private readonly IUserService _userService;
        private readonly ILogger<LoginWindow> _loginLogger;
        private readonly ILogger<RegisterWindow> _registerLogger;
        public RegisterWindow(IUserService userService, ILogger<RegisterWindow> registerLogger, ILogger<LoginWindow> loginLogger)
        {
            _userService = userService;
            _registerLogger = registerLogger;
            _loginLogger = loginLogger;
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow secondWindow = new LoginWindow(_userService, _loginLogger, _registerLogger);
            secondWindow.Show();
            this.Close();
        }


        private async void Register_Click(object sender, RoutedEventArgs e)
        {
            _registerLogger.LogInformation("Attempting to register the account.");

            var email = EmailInput.Text;
            var password = PasswordInput.Password;

            User user = new User()
            {
                Email = email,
                Password = password,
            };
            try
            {
                var userReg = await _userService.Register(user);

                _registerLogger.LogInformation("Successfully register the account.");

                AccountWindow secondWindow = new AccountWindow(userReg);
                secondWindow.Show();
                this.Close();
            }

            catch (Exception ex)
            {
                _registerLogger.LogError("Failed to register the account.");
            }
        }
    }
}
