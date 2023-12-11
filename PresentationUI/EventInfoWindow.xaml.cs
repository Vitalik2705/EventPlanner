using BLL.Services.Implementations;
using BLL.Services.Interfaces;
using DAL.Models;
using DAL.State.Authenticator;
using Microsoft.Extensions.Logging;
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
using System.Windows.Shapes;

namespace PresentationUI
{
    /// <summary>
    /// Interaction logic for EventInfoWindow.xaml
    /// </summary>
    public partial class EventInfoWindow : Window
    {

        private readonly INavigationService _navigationService;
        private readonly IEventService _eventService;
        private readonly IEventGuestService _eventGuestService;
        private readonly IEventRecipeService _eventRecipeService;
        private readonly IGuestService _guestService;
        private readonly IRecipeService _recipeService;
        private readonly IAuthenticator _authenticator;
        private readonly int _eventId;


        public EventInfoWindow(INavigationService navigationService, int eventId, IEventService eventService,
            IEventGuestService eventGuestService, IEventRecipeService eventRecipeService, IGuestService guestService,
            IRecipeService recipeService, IAuthenticator authenticator)
        {
            this._navigationService = navigationService;
            this._eventService = eventService;
            _eventService = eventService;
            _eventGuestService = eventGuestService;
            _eventRecipeService = eventRecipeService;
            _guestService = guestService;
            _recipeService = recipeService;
            _authenticator = authenticator;
            this._eventId = eventId;
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            // Отримайте подію (event) за допомогою поточного eventId (ваш логічний чи ідентифікатор події)
            var eventInfo = await _eventService.GetEventById(_eventId);

            if (eventInfo != null)
            {
                EventNameTextBlock.Text = eventInfo.Name;

                // Отримайте список гостей для події
                var guestsForEvent = await _eventGuestService.GetGuestsForEvent(_eventId);

                foreach (var eg in guestsForEvent)
                {
                    var guest = await _guestService.GetGuestById(eg.GuestId);
                    if (guest != null)
                    {
                        ListBoxItem guestItem = new ListBoxItem
                        {
                            Content = $"{guest.Name} {guest.Surname}",
                            // Якщо вам потрібно обробити подію при виборі гостя, додайте відповідний обробник подій.
                        };

                        GuestListBox.Items.Add(guestItem);
                    }
                }

                // Отримайте список рецептів для події
                var recipesForEvent = await _eventRecipeService.GetRecipesForEvent(_eventId);

                foreach (var er in recipesForEvent)
                {
                    var recipe = await _recipeService.GetRecipeById(er.RecipeId);
                    if (recipe != null)
                    {
                        ListBoxItem recipeItem = new ListBoxItem
                        {
                            Content = recipe.Name,
                            // Якщо вам потрібно обробити подію при виборі рецепта, додайте відповідний обробник подій.
                        };

                        EventListBox.Items.Add(recipeItem);
                    }
                }
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
