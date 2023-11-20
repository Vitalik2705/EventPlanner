// <copyright file="MainWindow.xaml.cs" company="PlaceholderCompany">
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
    using Microsoft.Extensions.Logging;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1601:Partial elements should be documented", Justification = "<Pending>")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1404:Code analysis suppression should have justification", Justification = "<Pending>")]
    public partial class MainWindow : Window, IMainWindow
    {
        private readonly IUserService _userService;
        private readonly INavigationService _navigationService;
        //private readonly ILogger<LoginWindow> _loginLogger;
        //private readonly ILogger<RegisterWindow> _registerLogger;

        public MainWindow()
        {
            //this.InitializeComponent();
        }

        public MainWindow(IUserService userService, INavigationService navigationService/*, ILogger<LoginWindow> loginLogger, ILogger<RegisterWindow> registerLogger*/)
        {
            _navigationService = navigationService;
            this._userService = userService;
            //this._loginLogger = loginLogger;
            //this._registerLogger = registerLogger;
            this.InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            _navigationService.NavigateTo<ILoginWindow>();

            //LoginWindow secondWindow = new LoginWindow(this._userService/*, _loginLogger, _registerLogger*/);
            //secondWindow.Show();
            this.Hide();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            _navigationService.NavigateTo<IGuestListWindow>(); ;
            this.Hide();
        }
    }
}
