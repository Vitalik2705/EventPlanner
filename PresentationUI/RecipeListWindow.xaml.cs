// <copyright file="RecipeListWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PresentationUI
{
    using BLL.Services.Interfaces;
    using DAL.State.Authenticator;
    using PresentationUI.Interfaces;
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    /// <summary>
    /// Interaction logic for RecipeListWindow.xaml.
    /// </summary>
    public partial class RecipeListWindow : Window, IRecipeListWindow
    {
        private readonly INavigationService _navigationService;
        private readonly IRecipeService _recipeService;
        private readonly IAuthenticator _authenticator;

        /// <summary>
        /// Initializes a new instance of the <see cref="RecipeListWindow"/> class.
        /// </summary>
        /// <param name="navigationService"></param>
        public RecipeListWindow(IRecipeService recipeService, INavigationService navigationService, IAuthenticator authenticator)
        {
            this._recipeService = recipeService;
            this._navigationService = navigationService;
            this._authenticator = authenticator;
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

        private void Add_Recipe_Click(object sender, RoutedEventArgs e)
        {
            this._navigationService.NavigateTo<IRecipeAddWindow>();
            this.Close();
        }

        private void Events_Click(object sender, RoutedEventArgs e)
        {
            this._navigationService.NavigateTo<IEventListWindow>();
            this.Close();
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

        private void Item_Click(object sender, RoutedEventArgs e)
        {
            this._navigationService.NavigateTo<IRecipeInfoWindow>();
            this.Close();
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = this.searchTextBoxRecipes.Text.ToLower();
            foreach (var item in this.itemListBoxRecipes.Items)
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

        private T? FindVisualChild<T>(DependencyObject parent)
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

        private async void LoadRecipes()
        {
            try
            {
                var recipes = await this._recipeService.GetAll();

                // Clear existing items in the ListBox
                this.itemListBoxRecipes.Items.Clear();

                foreach (var recipe in recipes)
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
                        Text = $"{recipe.Name}",
                    };

                    stackPanel.Children.Add(image);
                    stackPanel.Children.Add(textBlock);
                    listBoxItem.Content = stackPanel;

                    this.itemListBoxRecipes.Items.Add(listBoxItem);
                }
            }
            catch (Exception ex)
            {
                string exc = $"{ex}";
            }
        }

        private void itemListBoxRecipes_Loaded(object sender, RoutedEventArgs e)
        {
            this.LoadRecipes();
        }

        private void ___images_icons8_logout_50_png_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this._authenticator.Logout();

            this._navigationService.NavigateTo<IMainWindow>();
            this.Close();
        }
    }
}
