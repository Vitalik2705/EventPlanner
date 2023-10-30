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
        public MainWindow()
        {
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
