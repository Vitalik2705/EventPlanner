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
    /// Interaction logic for GuestAddWindow.xaml
    /// </summary>
    public partial class GuestAddWindow : Window, IGuestAddWindow
    {
        private readonly INavigationService _navigationService;
        private readonly IGuestService _guestService;

        public GuestAddWindow(IGuestService guestService, INavigationService navigationService)
        {
            _navigationService = navigationService;
            _guestService = guestService;
            InitializeComponent();
        }

        private async void AddGuest_Click(object sender, RoutedEventArgs e)
        {

            var name = this.FirstNameInput.Text;
            var surname = this.LastNameInput.Text;
            var gender = this.SexInput.SelectedItem != "Чоловік" ? Gender.Female : Gender.Male;

            Guest guest = new Guest()
            {
                Surname = surname,
                Name = name,
                Gender = gender,
            };
            try
            {
                await _guestService.AddGuest(guest);

                //AccountWindow secondWindow = new AccountWindow(userReg);

                _navigationService.NavigateTo<IGuestListWindow>();
                this.Close();
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
