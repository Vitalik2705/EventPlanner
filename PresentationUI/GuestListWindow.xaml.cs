// <copyright file="GuestListWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PresentationUI
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using BLL.Services.Interfaces;
    using DAL.State.Authenticator;
    using PresentationUI.Interfaces;

    /// <summary>
    /// Interaction logic for GuestListWindow.xaml.
    /// </summary>
    public partial class GuestListWindow : Window, IGuestListWindow
    {
        // private readonly IGuestService _guestService;
        private readonly INavigationService _navigationService;
        private readonly IGuestService _guestService;
        private readonly IEventGuestService _eventGuestService;
        private readonly IEventService _eventService;
        private readonly IAuthenticator _authenticator;

        /// <summary>
        /// Initializes a new instance of the <see cref="GuestListWindow"/> class.
        /// </summary>
        /// <param name="guestService"></param>
        /// <param name="navigationService"></param>
        public GuestListWindow(IGuestService guestService, INavigationService navigationService, IEventGuestService eventGuestService,
            IEventService eventService, IAuthenticator authenticator)
        {
            this._guestService = guestService;
            this._navigationService = navigationService;
            this._eventGuestService = eventGuestService;
            this._eventService = eventService;
            this._authenticator = authenticator;
            // LoadGuests();
            this.InitializeComponent();
            
        }

        private void Account_Page(object sender, RoutedEventArgs e)
        {
            this._navigationService.NavigateTo<IAccountWindow>();
            this.Close();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            // AccountWindow secondWindow = new AccountWindow();
            // secondWindow.Show();
            // this.Close();
        }

        private void Add_Guest_Click(object sender, RoutedEventArgs e)
        {
            this._navigationService.NavigateTo<IGuestAddWindow>();
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

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = this.searchTextBox.Text.ToLower();
            foreach (var item in this.itemListBox.Items)
            {
                if (item is ListBoxItem listBoxItem)
                {
                    var stackPanel = this.FindVisualChild<StackPanel>(listBoxItem);

                    if (stackPanel != null)
                    {
                        var textBlock = this.FindVisualChild<TextBlock>(stackPanel);

                        if (textBlock != null)
                        {
                            string itemText = textBlock.Text.ToLower();

                            if (itemText.Contains(searchText))
                            {
                                listBoxItem.Visibility = Visibility.Visible;
                            }
                            else
                            {
                                listBoxItem.Visibility = Visibility.Collapsed;
                            }
                        }
                    }
                }
            }
        }

        private async void LoadGuests()
        {
            try
            {
                var guests = await this._guestService.GetGuestsAsync();

                // Clear existing items in the ListBox
                this.itemListBox.Items.Clear();

                foreach (var guest in guests)
                {
                    ListBoxItem listBoxItem = new ListBoxItem
                    {
                        Height = 50,
                        Margin = new Thickness(0, 0, 0, 15),
                        Style = this.FindResource("MaterialDesignCardsListBoxItem") as Style, // Use the appropriate resource key
                        Tag = guest.GuestId
                    };

                    StackPanel stackPanel = new StackPanel
                    {
                        Background = Brushes.White,
                        Orientation = Orientation.Horizontal,
                    };

                    Image image = new Image
                    {
                        Width = 50,
                        Height = 40,
                        Source = new BitmapImage(new Uri("images/Ellipse 1.png", UriKind.RelativeOrAbsolute)),
                    };

                    TextBlock textBlock = new TextBlock
                    {
                        Margin = new Thickness(10, 6, 0, 0),
                        FontSize = 25,
                        Text = $"{guest.Name} {guest.Surname}",
                    };

                    stackPanel.Children.Add(image);
                    stackPanel.Children.Add(textBlock);
                    listBoxItem.Content = stackPanel;

                    this.itemListBox.Items.Add(listBoxItem);
                }
            }
            catch (Exception ex)
            {
                string exc = $"{ex}";
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (itemListBox.SelectedItem != null)
            {
                ListBoxItem selectedListBoxItem = (ListBoxItem)itemListBox.SelectedItem;

                int guestId = (int)selectedListBoxItem.Tag;

                GuestInfoWindow guestInfoWindow = new GuestInfoWindow(_navigationService, _guestService, _eventGuestService, _eventService, guestId);
                this.Close();
                guestInfoWindow.Show();
            }
        }


        // Call this method in the constructor or when needed to load guests
        private void LoadGuests_Click(object sender, RoutedEventArgs e)
        {
            this.LoadGuests();
        }

        private T FindVisualChild<T>(DependencyObject parent)
            where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);

                if (child != null && child is T)
                {
                    return (T)child;
                }
                else
                {
                    T childOfChild = this.FindVisualChild<T>(child);

                    if (childOfChild != null)
                    {
                        return childOfChild;
                    }
                }
            }

            return null;
        }

        private void ___images_icons8_logout_50_png_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this._authenticator.Logout();

            this._navigationService.NavigateTo<IMainWindow>();
            this.Close();
        }
    }
}
