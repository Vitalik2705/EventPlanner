using BLL.Services.Interfaces;
using DAL.Models;
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

namespace PresentationUI
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private readonly IUserService _userService;
        public RegisterWindow(IUserService userService)
        {
            _userService = userService;
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {


            LoginWindow secondWindow = new LoginWindow(_userService);
            secondWindow.Show();
            this.Close();
        }


        private async void Register_Click(object sender, RoutedEventArgs e)
        {
            var email = EmailInput.Text;
            var password = PasswordInput.Password;

            User user = new User()
            {
                Email = email,
                Password = password,
            };

            var userReg = await _userService.Register(user);
            //User user = null;
            AccountWindow secondWindow = new AccountWindow(userReg);
            secondWindow.Show();
            this.Close();
        }
    }
}
