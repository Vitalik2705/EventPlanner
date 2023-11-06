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

namespace PresentationUI
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly IUserService _userService;
        public LoginWindow(IUserService userService)
        {
            _userService = userService;
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow secondWindow = new RegisterWindow(_userService);
            secondWindow.Show();
            this.Close();
        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            var email = EmailInput.Text;
            var password = PasswordInput.Password;

            var user = await _userService.Login(password, email);
            //User user = null;
            AccountWindow secondWindow = new AccountWindow(user);
            secondWindow.Show();
            this.Close();
        }
    }
}
