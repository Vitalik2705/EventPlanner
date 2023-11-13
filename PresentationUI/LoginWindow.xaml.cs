// <copyright file="LoginWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PresentationUI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using BLL.Services.Interfaces;
    using BLL.Services.Repositories;
    using DAL.Data;
    using DAL.Models;

    /// <summary>
    /// Interaction logic for LoginWindow.xaml.
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly IUserService _userService;

        public LoginWindow(IUserService userService)
        {
            this._userService = userService;
            this.InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow secondWindow = new RegisterWindow(this._userService);
            secondWindow.Show();
            this.Close();
        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            var email = this.EmailInput.Text;
            var password = this.PasswordInput.Password;

            var user = await this._userService.Login(password, email);

            // User user = null;
            AccountWindow secondWindow = new AccountWindow(user);
            secondWindow.Show();
            this.Close();
        }
    }
}
