// <copyright file="RegisterWindow.xaml.cs" company="PlaceholderCompany">
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

    /// <summary>
    /// Interaction logic for Register.xaml.
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private readonly IUserService _userService;

        public RegisterWindow(IUserService userService)
        {
            this._userService = userService;
            this.InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow secondWindow = new LoginWindow(this._userService);
            secondWindow.Show();
            this.Close();
        }

        private async void Register_Click(object sender, RoutedEventArgs e)
        {
            var email = this.EmailInput.Text;
            var password = this.PasswordInput.Password;

            User user = new User()
            {
                Email = email,
                Password = password,
            };

            var userReg = await this._userService.Register(user);

            // User user = null;
            AccountWindow secondWindow = new AccountWindow(userReg);
            secondWindow.Show();
            this.Close();
        }
    }
}
