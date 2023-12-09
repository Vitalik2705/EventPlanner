using BLL.Services.Interfaces;
using PresentationUI.Interfaces;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PresentationUI
{
    /// <summary>
    /// Interaction logic for GuestInfo4Window.xaml
    /// </summary>
    public partial class GuestInfoWindow : Window
    {

        private readonly INavigationService _navigationService;
        private readonly IGuestService _guestService;
        private readonly int _guestId;

        public GuestInfoWindow(INavigationService navigationService, IGuestService guestService, int guestId)
        {
            this._navigationService = navigationService;
            this._guestService = guestService;
            this._guestId = guestId;
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            var guest = await _guestService.GetGuestById(_guestId);

            if (guest != null)
            {
                LastNameTextBlock.Text = guest.Surname;
                FirstNameTextBlock.Text = guest.Name;
                GenderTextBlock.Text = guest.Gender.ToString() == "Male" ? "Чоловік" : "Жінка";
                //EventTextBlock.Text = guest.Event;
            }
        }

        private void Guests_Click(object sender, RoutedEventArgs e)
        {
            this._navigationService.NavigateTo<IGuestListWindow>();
            this.Close();
        }

        private void Events_Click(object sender, RoutedEventArgs e)
        {
            this._navigationService.NavigateTo<IEventListWindow>();
            this.Close();
        }

        private void Recipes_Click(object sender, RoutedEventArgs e)
        {
            this._navigationService.NavigateTo<IRecipeListWindow>();
            this.Close();
        }
    }
}
