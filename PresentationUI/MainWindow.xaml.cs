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
    public partial class MainWindow : Window
    {
        private readonly IUserService _userService;
        private readonly ILogger<LoginWindow> _loginLogger;
       private readonly ILogger<RegisterWindow> _registerLogger;
        private MainWindow mainWindow;

        //public MainWindow()
        //{
        //    //this.InitializeComponent();
        //}

        public MainWindow(IUserService userService/*, ILogger<LoginWindow> loginLogger, ILogger<RegisterWindow> registerLogger*/)
        {
            this._userService = userService;
            //this._loginLogger = loginLogger;
            //this._registerLogger = registerLogger;
            this.InitializeComponent();
        }

        public MainWindow(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow secondWindow = new LoginWindow(this._userService, _loginLogger, _registerLogger);
            secondWindow.Show();
            this.Hide();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            GuestListWindow secondWindow = new GuestListWindow();
            secondWindow.Show();
            this.Hide();
        }
    }
}
