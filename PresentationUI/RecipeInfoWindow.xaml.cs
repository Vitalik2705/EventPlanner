// <copyright file="RecipeInfoWindow.xaml.cs" company="PlaceholderCompany">
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
    using Microsoft.Extensions.Logging;
    using PresentationUI.Interfaces;

    /// <summary>
    /// Interaction logic for RecipeInfoWindow.xaml.
    /// </summary>
    public partial class RecipeInfoWindow : Window, IRecipeInfoWindow
    {
        private readonly IRecipeService _recipeService;
        private readonly INavigationService _navigationService;
        private readonly IAuthenticator _authenticator;
        private readonly int _recipeId;

        public RecipeInfoWindow(IRecipeService recipeService, INavigationService navigationService, IAuthenticator authenticator, int recipeId)
        {
            this._recipeService = recipeService;
            this._navigationService = navigationService;
            this._authenticator = authenticator;
            this._recipeId = recipeId;
            this.InitializeComponent();
            Loaded += OnLoaded;
        }
        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            // Отримайте подію (event) за допомогою поточного eventId (ваш логічний чи ідентифікатор події)
            var recipeInfo = await _recipeService.GetRecipeById(_recipeId);

            if (recipeInfo != null)
            {
                RecipeNameTextBlock.Text = recipeInfo.Name;

                RecipeTimeTextBlock.Text = recipeInfo.CookingTime.ToString() + " хв";

                RecipeCaloriesTextBlock.Text = recipeInfo.Calories.ToString();

                //RecipeDescriptionTextBlock.Text = recipeInfo.Description;

                // Отримайте список гостей для події
                //var ingredientsForRecipe = await _eventGuestService.GetGuestsForEvent(_recipeId);

                //foreach (var eg in guestsForEvent)
                //{
                //    var guest = await _guestService.GetGuestById(eg.GuestId);
                //    if (guest != null)
                //    {
                //        ListBoxItem guestItem = new ListBoxItem
                //        {
                //            Content = $"{guest.Name} {guest.Surname}",
                //            // Якщо вам потрібно обробити подію при виборі гостя, додайте відповідний обробник подій.
                //        };

                //        GuestListBox.Items.Add(guestItem);
                //    }
                //}

                //// Отримайте список рецептів для події
                //var recipesForEvent = await _eventRecipeService.GetRecipesForEvent(_eventId);

                //foreach (var er in recipesForEvent)
                //{
                //    var recipe = await _recipeService.GetRecipeById(er.RecipeId);
                //    if (recipe != null)
                //    {
                //        ListBoxItem recipeItem = new ListBoxItem
                //        {
                //            Content = recipe.Name,
                //            // Якщо вам потрібно обробити подію при виборі рецепта, додайте відповідний обробник подій.
                //        };

                //        EventListBox.Items.Add(recipeItem);
                //    }
                //}
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
