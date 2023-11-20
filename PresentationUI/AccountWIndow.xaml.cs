﻿// <copyright file="AccountWIndow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PresentationUI
{
    using System.Windows;
    using DAL.Models;

    /// <summary>
    /// Interaction logic for AccountWIndow.xaml.
    /// </summary>
    public partial class AccountWindow : Window
    {
        private readonly INavigationService _navigationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountWindow"/> class.
        /// </summary>
        /// <param name="user">name.</param>
        public AccountWindow(User user, INavigationService navigationService)
        {
            _navigationService = navigationService;
            this.InitializeComponent();
            string userName = $"{user.Surname} {user.Name}";
            this.UserName.Text = userName;
            this.Email.Text = user.Email;
            this.Phone.Text = user.PhoneNumber;
            _navigationService = navigationService;
        }

        private void Guest_Page(object sender, RoutedEventArgs e)
        {
            _navigationService.NavigateTo<IGuestListWindow>();
            this.Close();
        }
    }
}
