using DAL.Data;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using BLL.Services.Repositories;
using BLL.Services.Interfaces;

namespace PresentationUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IUserService _userService;
        public MainWindow(IUserService userService)
        {
            _userService = userService;
            InitializeComponent();
        }

        public MainWindow() { }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow secondWindow = new LoginWindow(_userService);
            secondWindow.Show();
            this.Hide();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            //List<IngredientUnit> GetIngredients = _ingredients.GetAll().ToList();
            //Label Ingred = new Label();
            //Ingred.Content = $"Інгредієнт: {GetIngredients[0].Ingredient}. Одиниця виміру: {GetIngredients[0].Unit}. Кількість: {GetIngredients[0].Amount}\n";
            //Ingred.FontSize = 30;
            //var thickness = new Thickness(30, 100, 0, 0);
            //Ingred.Margin = thickness;
        }
    }
}
