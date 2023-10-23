﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EventPlanner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public MainWindow()
        //{
        //    InitializeComponent();
        //}

        private void Ingredients_Click(object sender, RoutedEventArgs e)
        {
            Label Ingred = new Label();
            Ingred.Content = "Something";
            Ingred.FontSize = 30;
            Thickness thickness = new Thickness(30, 100, 0, 0);
            Ingred.Margin = thickness;

            Grid_First_Page.Children.Add(Ingred);
        }
    }
}
