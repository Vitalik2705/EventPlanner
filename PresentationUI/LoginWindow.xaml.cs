using DAL.Data;
using DAL.Models;
using BLL.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PresentationUI
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow secondWindow = new RegisterWindow();
            secondWindow.Show();
            this.Close();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            AccountWindow secondWindow = new AccountWindow();
            secondWindow.Show();
            this.Close();
        }
    }
}
