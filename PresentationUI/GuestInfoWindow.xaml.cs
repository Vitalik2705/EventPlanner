using BLL.Services.Interfaces;
using DAL.State.Authenticator;
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
        private readonly IEventGuestService _eventGuestService;
        private readonly IEventService _eventService;
        private readonly IAuthenticator _authenticator;
        private readonly int _guestId;

        public GuestInfoWindow(INavigationService navigationService, IGuestService guestService, IEventGuestService eventGuestService,
            IEventService eventService, int guestId, IAuthenticator authenticator)
        {
            this._navigationService = navigationService;
            this._guestService = guestService;
            this._eventGuestService = eventGuestService;
            this._eventService = eventService;
            this._guestId = guestId;
            this._authenticator = authenticator;
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

                var eventsForGuest = await _eventGuestService.GetEventsForGuest(_guestId);

                var eventNames = new List<string>();
                foreach (var eg in eventsForGuest)
                {
                    var eventInfo = await _eventService.GetEventById(eg.EventId);
                    if (eventInfo != null)
                    {
                        eventNames.Add(eventInfo.Name);
                    }
                }

                EventTextBlock.Text = string.Join(Environment.NewLine, eventNames);
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

        private void ___images_icons8_logout_50_png_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this._authenticator.Logout();

            this._navigationService.NavigateTo<IMainWindow>();
            this.Close();
        }
    }
}
