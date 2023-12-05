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
    using PresentationUI.Interfaces;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1601:Partial elements should be documented", Justification = "<Pending>")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1404:Code analysis suppression should have justification", Justification = "<Pending>")]
    public partial class MainWindow : Window, IMainWindow
    {
        private readonly IUserService _userService;
        private readonly INavigationService _navigationService;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public MainWindow()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        /// <param name="userService"></param>
        /// <param name="navigationService"></param>
        public MainWindow(IUserService userService, INavigationService navigationService)
        {
            this._navigationService = navigationService;
            this._userService = userService;
            this.InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            this._navigationService.NavigateTo<ILoginWindow>();
            this.Hide();
        }

        private void AboutUs_Click(object sender, RoutedEventArgs e)
        {
            this._navigationService.NavigateTo<IAboutUsWindow>();
            this.Hide();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            this._navigationService.NavigateTo<IGuestListWindow>();
            this.Hide();
        }
    }
}
