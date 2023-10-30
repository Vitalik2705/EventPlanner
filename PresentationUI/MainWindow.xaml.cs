using DAL.Data;
using DAL.Models;
using DAL.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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
        private void Ingredients_Click(object sender, RoutedEventArgs e)
        {
            List<IngredientUnit> GetIngredients = _ingredients.GetAll().ToList();
            Label Ingred = new Label();
            Ingred.Content = $"Інгредієнт: {GetIngredients[0].Ingredient}. Одиниця виміру: {GetIngredients[0].Unit}. Кількість: {GetIngredients[0].Amount}\n";
            Ingred.FontSize = 30;
            var thickness = new Thickness(30, 100, 0, 0);
            Ingred.Margin = thickness;

            Grid_First_Page.Children.Add(Ingred);
        }
    }
}
