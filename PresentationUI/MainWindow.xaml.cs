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

    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1601:Partial elements should be documented", Justification = "<Pending>")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1404:Code analysis suppression should have justification", Justification = "<Pending>")]
    public partial class MainWindow : Window
    {
        private readonly IUserService _userService;

        public MainWindow()
        {
            this.InitializeComponent();
        }

        public MainWindow(IUserService userService)
        {
            this._userService = userService;
            this.InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow secondWindow = new LoginWindow(this._userService);
            secondWindow.Show();
            this.Hide();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            // List<IngredientUnit> GetIngredients = _ingredients.GetAll().ToList();
            // Label Ingred = new Label();
            // Ingred.Content = $"Інгредієнт: {GetIngredients[0].Ingredient}. Одиниця виміру: {GetIngredients[0].Unit}. Кількість: {GetIngredients[0].Amount}\n";
            // Ingred.FontSize = 30;
            // var thickness = new Thickness(30, 100, 0, 0);
            // Ingred.Margin = thickness;
        }
    }
}
