using DAL.Data;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using BLL.Services.Repositories;

namespace PresentationUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IGenericRepository<IngredientUnit> _ingredients;

        public MainWindow(IGenericRepository<IngredientUnit> ingredients)
        {
            _ingredients = ingredients;
            InitializeComponent();
        }

        public MainWindow() { }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow secondWindow = new LoginWindow();
            secondWindow.Show();
            this.Close();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            List<IngredientUnit> GetIngredients = _ingredients.GetAll().ToList();
            Label Ingred = new Label();
            Ingred.Content = $"Інгредієнт: {GetIngredients[0].Ingredient}. Одиниця виміру: {GetIngredients[0].Unit}. Кількість: {GetIngredients[0].Amount}\n";
            Ingred.FontSize = 30;
            var thickness = new Thickness(30, 100, 0, 0);
            Ingred.Margin = thickness;
        }
    }
}
