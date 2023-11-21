﻿// <copyright file="GuestListWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PresentationUI
{
    using BLL.Services.Interfaces;
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

    /// <summary>
    /// Interaction logic for GuestListWindow.xaml.
    /// </summary>
    public partial class GuestListWindow : Window, IGuestListWindow
    {
        //private readonly IGuestService _guestService;
        private readonly INavigationService _navigationService;
        private readonly IGuestService _guestService;

        public GuestListWindow(IGuestService guestService, INavigationService navigationService)
        {
            _guestService = guestService;
            _navigationService = navigationService;
            //LoadGuests();

            this.InitializeComponent();
        }

        private void Account_Page(object sender, RoutedEventArgs e)
        {
            // AccountWindow secondWindow = new AccountWindow();
            // secondWindow.Show();
            // this.Close();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            // AccountWindow secondWindow = new AccountWindow();
            // secondWindow.Show();
            // this.Close();
        }

        private void Add_Guest_Click(object sender, RoutedEventArgs e)
        {
            _navigationService.NavigateTo<IGuestAddWindow>();
            this.Close();
        }

        private void Events_Click(object sender, RoutedEventArgs e)
        {
            EventListWindow secondWindow = new EventListWindow(_navigationService);
            secondWindow.Show();
            this.Close();
        }

        private void Recipes_Click(object sender, RoutedEventArgs e)
        {
            RecipeListWindow secondWindow = new RecipeListWindow(_navigationService);
            secondWindow.Show();
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
                var guests = await _guestService.GetGuestsAsync();

                // Clear existing items in the ListBox
                itemListBox.Items.Clear();

                foreach (var guest in guests)
                {
                    ListBoxItem listBoxItem = new ListBoxItem
                    {
                        Height = 50,
                        Margin = new Thickness(0, 0, 0, 15),
                        Style = FindResource("MaterialDesignCardsListBoxItem") as Style // Use the appropriate resource key
                    };

                    StackPanel stackPanel = new StackPanel
                    {
                        Background = Brushes.White,
                        Orientation = Orientation.Horizontal
                    };

                    Image image = new Image
                    {
                        Width = 50,
                        Height = 40,
                        Source = new BitmapImage(new Uri("images/Ellipse 1.png", UriKind.RelativeOrAbsolute))
                    };

                    TextBlock textBlock = new TextBlock
                    {
                        Margin = new Thickness(10, 6, 0, 0),
                        FontSize = 25,
                        Text = $"{guest.Name} {guest.Surname}"
                    };

                    stackPanel.Children.Add(image);
                    stackPanel.Children.Add(textBlock);
                    listBoxItem.Content = stackPanel;

                    itemListBox.Items.Add(listBoxItem);
                }
            }
            catch (Exception ex)
            {
                // Handle exception
            }
        }

        // Call this method in the constructor or when needed to load guests
        private void LoadGuests_Click(object sender, RoutedEventArgs e)
        {
            LoadGuests();
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
    }
}
