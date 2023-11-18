// <copyright file="GuestAddWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PresentationUI
{
    using System;
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
    using System.Windows.Shapes;

    /// <summary>
    /// Interaction logic for GuestAddWindow.xaml
    /// </summary>
    public partial class GuestAddWindow : Window
    {
        public GuestAddWindow()
        {
            this.InitializeComponent();
        }

        private void Guests_Click(object sender, RoutedEventArgs e)
        {
            GuestListWindow secondWindow = new GuestListWindow();
            secondWindow.Show();
            this.Close();
        }

        private void Events_Click(object sender, RoutedEventArgs e)
        {
            EventListWindow secondWindow = new EventListWindow();
            secondWindow.Show();
            this.Close();
        }
    }
}
