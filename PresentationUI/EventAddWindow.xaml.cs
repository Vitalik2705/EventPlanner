// <copyright file="EventAddWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PresentationUI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
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
    using BLL.Services.Interfaces;
    using BLL.Services.State.Authenticator;
    using DAL.Models;
    using DAL.State.Authenticator;
    using MaterialDesignThemes.Wpf;
    using PresentationUI.Interfaces;

    /// <summary>
    /// Interaction logic for EventAddWindow.xaml.
    /// </summary>
    public partial class EventAddWindow : Window, IEventAddWindow
    {
        private readonly INavigationService _navigationService;
        private readonly IEventService _eventService;
        private readonly IGuestService _guestService;
        private readonly IRecipeService _recipeService;
        private readonly IEventRecipeService _eventRecipeService;
        private readonly IEventGuestService _eventGuestService;
        private readonly IAuthenticator _authenticator;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventAddWindow"/> class.
        /// </summary>
        /// <param name="navigationService"></param>
        public EventAddWindow(INavigationService navigationService, IEventService eventService, IGuestService guestService,
            IRecipeService recipeService, IAuthenticator authenticator, IEventRecipeService eventRecipeService, IEventGuestService eventGuestService)
        {
            this._navigationService = navigationService;
            this._eventService = eventService;
            this._guestService = guestService;
            this._recipeService = recipeService;
            this._eventGuestService = eventGuestService;
            this._eventRecipeService = eventRecipeService;
            this._authenticator = authenticator;
            this.InitializeComponent();
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

        private readonly List<ComboBox> comboBoxList = new List<ComboBox>();
        private List<Button> deleteButtonList = new List<Button>();
        private double verticalOffset = 230;

        private async void AddGuestsButton_Click(object sender, RoutedEventArgs e)
        {
            ComboBox newComboBox = new ComboBox
            {
                Name = "GuestsInput" + this.comboBoxList.Count,
                Style = (Style)this.FindResource("MaterialDesignComboBox"),
                Width = 230,
                Height = 50,
                FontSize = 17,
                BorderThickness = new Thickness(0, 0, 0, 1.5),
                BorderBrush = new SolidColorBrush(Color.FromRgb(86, 90, 123)),
            };

            var guests = await this._guestService.GetGuestsAsync();
            foreach (var guest in guests)
            {
                newComboBox.Items.Add(new ComboBoxItem { Content = $"{guest.Name} {guest.Surname}" });
            }

            Button deleteButton = new Button
            {
                Width = 30,
                Height = 30,
                Background = new SolidColorBrush(Color.FromRgb(86, 90, 123)),
                Foreground = Brushes.White,
                Content = new Image
                {
                    Width = 23,
                    Height = 19,
                    Source = new BitmapImage(new Uri("images/plus (1).png", UriKind.Relative)),
                },
            };

            deleteButton.Click += (s, args) =>
            {
                if (this.comboBoxList.Count > 0)
                {
                    int index = this.comboBoxList.Count - 1;
                    this.MyCanvas.Children.Remove(this.comboBoxList[index]);
                    this.MyCanvas.Children.Remove(this.deleteButtonList[index]);
                    this.comboBoxList.RemoveAt(index);
                    this.deleteButtonList.RemoveAt(index);

                    if (index < this.verticalOffset)
                    {
                        this.verticalOffset -= 70;
                    }
                }
            };

            Canvas.SetLeft(newComboBox, 80);
            Canvas.SetTop(newComboBox, this.verticalOffset);
            this.MyCanvas.Children.Add(newComboBox);

            Canvas.SetLeft(deleteButton, 25);
            Canvas.SetTop(deleteButton, this.verticalOffset + 20);
            this.MyCanvas.Children.Add(deleteButton);

            this.verticalOffset += 70;

            this.comboBoxList.Add(newComboBox);
            this.deleteButtonList.Add(deleteButton);
        }

        private readonly List<ComboBox> comboBoxDishesList = new List<ComboBox>();
        private List<Button> deleteButtonDishesList = new List<Button>();
        private double verticalOffsetDishes = 230;

        private async void AddDishesButton_Click(object sender, RoutedEventArgs e)
        {
            ComboBox newComboBox = new ComboBox
            {
                Name = "DishesInput" + comboBoxDishesList.Count,
                Style = (Style)FindResource("MaterialDesignComboBox"),
                Width = 230,
                Height = 50,
                FontSize = 17,
                BorderThickness = new Thickness(0, 0, 0, 1.5),
                BorderBrush = new SolidColorBrush(Color.FromRgb(86, 90, 123)),
            };

            var recipes = (await this._recipeService.GetAll()).ToList();
            foreach (var recipe in recipes)
            {
                newComboBox.Items.Add(new ComboBoxItem { Content = $"{recipe.Name}" });
            }

            Button deleteButton = new Button
            {
                Width = 30,
                Height = 30,
                Background = new SolidColorBrush(Color.FromRgb(86, 90, 123)),
                Foreground = Brushes.White,
                Content = new Image
                {
                    Width = 23,
                    Height = 19,
                    Source = new BitmapImage(new Uri("images/plus (1).png", UriKind.Relative)),
                },
            };

            deleteButton.Click += (s, args) =>
            {
                if (this.comboBoxDishesList.Count > 0)
                {
                    int index = this.comboBoxDishesList.Count - 1;
                    this.MyCanvas.Children.Remove(this.comboBoxDishesList[index]);
                    this.MyCanvas.Children.Remove(this.deleteButtonDishesList[index]);
                    this.comboBoxDishesList.RemoveAt(index);
                    this.deleteButtonDishesList.RemoveAt(index);

                    if (index < this.verticalOffsetDishes)
                    {
                        this.verticalOffsetDishes -= 70;
                    }
                }
            };

            Canvas.SetLeft(newComboBox, 470);
            Canvas.SetTop(newComboBox, this.verticalOffsetDishes);
            this.MyCanvas.Children.Add(newComboBox);

            Canvas.SetLeft(deleteButton, 415);
            Canvas.SetTop(deleteButton, this.verticalOffsetDishes + 20);
            this.MyCanvas.Children.Add(deleteButton);

            this.verticalOffsetDishes += 70;

            this.comboBoxDishesList.Add(newComboBox);
            this.deleteButtonDishesList.Add(deleteButton);
        }

        private async void AddEventButton_Click(object sender, RoutedEventArgs e)
        {
            var nameEvent = this.EventNameInput.Text;

            //var comboBoxGuests = new List<string>();
            var guests = new List<Guest>();
            foreach (var comboBoxGuest in this.comboBoxList)
            {
                var nameOfGuest = comboBoxGuest.Text.Split(' ')[0];
                var surnameOfGuest = comboBoxGuest.Text.Split(' ')[1];
                var guest = await this._guestService.GetGuest(e => e.Name == nameOfGuest && e.Surname == surnameOfGuest);

                guests.Add(guest);
            }

            var recipes = new List<Recipe>();
            foreach (var comboBoxRecipe in this.comboBoxDishesList)
            {
                var nameOfRecipe = comboBoxRecipe.Text;
                var recipe = await this._recipeService.GetRecipe(e => e.Name == nameOfRecipe);
                recipes.Add(recipe);
            }

            var eventGR = new Event()
            {
                Name = nameEvent,
                UserId = this._authenticator.CurrentUser.UserId,
                CreatedDate = DateTime.UtcNow,
            };

            await this._eventService.AddEvent(eventGR);

            var eventGuests = new List<EventGuest>();
            for (int i = 0; i < guests.Count; i++)
            {
                var eventGuest = new EventGuest()
                {
                    EventId = eventGR.EventId,
                    GuestId = guests[i].GuestId,
                };
                await this._eventGuestService.AddEventGuest(eventGuest);
            }

            for (int i = 0; i < recipes.Count; i++)
            {
                var eventRecipe = new EventRecipe()
                {
                    EventId = eventGR.EventId,
                    RecipeId = recipes[i].RecipeId,
                };
                await this._eventRecipeService.AddEventRecipe(eventRecipe);
            }

            this._navigationService.NavigateTo<IEventListWindow>();
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
