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
    public partial class AboutUsWindow : Window, IAboutUsWindow
    {
        private readonly INavigationService _navigationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AboutUsWindow"/> class.
        /// </summary>
        /// <param name="navigationService"></param>
        public AboutUsWindow(INavigationService navigationService)
        {
            this._navigationService = navigationService;

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
            this._navigationService.NavigateTo<IOpportunitiesWindow>();
            this.Hide();
        }

        private void Gmail_CLick(object sender, RoutedEventArgs e)
        {
            string emailAddress = "vitok2misze@gmail.com";

            string mailtoUrl = $"mailto:{emailAddress}";

            try
            {
                System.Diagnostics.Process.Start("cmd", $"/c start {mailtoUrl}");
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void Github_CLick(object sender, RoutedEventArgs e)
        {
            string githubUrl = "https://github.com/Vitalik2705/EventPlanner";

            try
            {
                System.Diagnostics.Process.Start("cmd", $"/c start {githubUrl}");
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void Instagram_CLick(object sender, RoutedEventArgs e)
        {
            string githubUrl = "https://github.com/Vitalik2705/EventPlanner";

            try
            {
                System.Diagnostics.Process.Start("cmd", $"/c start {githubUrl}");
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void Telegram_CLick(object sender, RoutedEventArgs e)
        {
            string githubUrl = "https://github.com/Vitalik2705/EventPlanner";

            try
            {
                System.Diagnostics.Process.Start("cmd", $"/c start {githubUrl}");
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
