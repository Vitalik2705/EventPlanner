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
    /// Interaction logic for AccountWIndow.xaml
    /// </summary>
    public partial class AccountWindow : Window
    {
        
        public AccountWindow(User user)
        {

            InitializeComponent();
            string userName = $"{user.Surname} {user.Name}";

            

            //TextBlock userNameTextBlock = UserName;

            // Встановіть текст для TextBlock
            UserName.Text = userName;
            //TextBlock? emailTextBlock = FindName("Email") as TextBlock;
            //TextBlock? phoneTextBlock = FindName("Phone") as TextBlock;
            //if (userNameTextBlock != null)
            //{
            Email.Text = user.Email;
            Phone.Text = user.PhoneNumber;
            //}

            
        }
    }
}
