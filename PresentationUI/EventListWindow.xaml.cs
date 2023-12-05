// <copyright file="EventListWindow.xaml.cs" company="PlaceholderCompany">
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
    using BLL.Services.Interfaces;
    using DAL.State.Authenticator;
    using PresentationUI.Interfaces;

    /// <summary>
    /// Interaction logic for EventListWindow.xaml.
    /// </summary>
    public partial class EventListWindow : Window, IEventListWindow
    {
        private readonly INavigationService _navigationService;
        private readonly IEventService _eventService;
        private readonly IAuthenticator _autheticator;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventListWindow"/> class.
        /// </summary>
        /// <param name="navigationService"></param>
        public EventListWindow(INavigationService navigationService, IEventService eventService, IAuthenticator authenticator)
        {
            this._navigationService = navigationService;
            this._eventService = eventService;
            this._autheticator = authenticator;
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

        private void Guests_Click(object sender, RoutedEventArgs e)
        {
            this._navigationService.NavigateTo<IGuestListWindow>();
            this.Close();
        }

        private void Recipes_Click(object sender, RoutedEventArgs e)
        {
            this._navigationService.NavigateTo<IRecipeListWindow>();
            this.Close();
        }

        private void Add_Event_Click(object sender, RoutedEventArgs e)
        {
            this._navigationService.NavigateTo<IEventAddWindow>();
            this.Close();
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = this.searchTextBoxEvents.Text.ToLower();
            foreach (var item in this.itemListBoxEvents.Items)
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

        private async void LoadGuests()
        {
            try
            {
                var events = await this._eventService.GetAll(e => e.UserId == this._autheticator.CurrentUser.UserId);

                // Clear existing items in the ListBox
                this.itemListBoxEvents.Items.Clear();

                foreach (var even in events)
                {
                    ListBoxItem listBoxItem = new ListBoxItem
                    {
                        Height = 50,
                        Margin = new Thickness(0, 0, 0, 15),
                        Style = this.FindResource("MaterialDesignCardsListBoxItem") as Style, // Use the appropriate resource key
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
                        Text = $"{even.Name}",
                    };

                    stackPanel.Children.Add(image);
                    stackPanel.Children.Add(textBlock);
                    listBoxItem.Content = stackPanel;

                    this.itemListBoxEvents.Items.Add(listBoxItem);
                }
            }
            catch (Exception ex)
            {
                string exc = $"{ex}";
            }
        }

        private void itemListBoxEvents_Loaded(object sender, RoutedEventArgs e)
        {
            this.LoadGuests();
        }
    }
}