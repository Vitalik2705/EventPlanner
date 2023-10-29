using DAL.Data;
using DAL.Models;
using DAL.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PresentationUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly GenericRepository<IngredientUnit> _ingredients;

        private EventPlannerContextFactory _contextFactory;
        public MainWindow()
        {
            _contextFactory = new EventPlannerContextFactory();
            _ingredients = new GenericRepository<IngredientUnit>(_contextFactory.CreateDbContext(new string[1]));
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow secondWindow = new LoginWindow();
            secondWindow.Show();
            this.Close();
        }

    }
}
