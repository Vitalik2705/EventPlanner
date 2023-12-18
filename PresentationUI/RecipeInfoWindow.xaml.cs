// <copyright file="RecipeInfoWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PresentationUI
{
    using System;
    using System.IO;
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
    using BLL.Services.Implementations;
    using BLL.Services.Interfaces;
    using DAL.Models;
    using DAL.State.Authenticator;
    using Microsoft.Extensions.Logging;
    using PresentationUI.Interfaces;
    using Path = System.IO.Path;

    /// <summary>
    /// Interaction logic for RecipeInfoWindow.xaml.
    /// </summary>
    public partial class RecipeInfoWindow : Window, IRecipeInfoWindow
    {
        private readonly IRecipeService _recipeService;
        private readonly IIngredientUnitRecipeService _ingredientUnitRecipeService;
        private readonly IIngredientUnitService _ingredientUnitService;
        private readonly INavigationService _navigationService;
        private readonly IAuthenticator _authenticator;
        private readonly int _recipeId;

        public RecipeInfoWindow(IRecipeService recipeService, IIngredientUnitRecipeService ingredientUnitRecipeService, IIngredientUnitService ingredientUnitService, INavigationService navigationService, IAuthenticator authenticator, int recipeId)
        {
            this._recipeService = recipeService;
            this._ingredientUnitRecipeService = ingredientUnitRecipeService;
            this._ingredientUnitService = ingredientUnitService;
            this._navigationService = navigationService;
            this._authenticator = authenticator;
            this._recipeId = recipeId;
            this.InitializeComponent();
            Loaded += OnLoaded;
        }
        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            var recipeInfo = await _recipeService.GetRecipeById(_recipeId);

            if (recipeInfo != null)
            {
                RecipeNameTextBlock.Text = recipeInfo.Name;

                RecipeTimeTextBlock.Text = recipeInfo.CookingTime.ToString() + " хв";

                RecipeCaloriesTextBlock.Text = recipeInfo.Calories.ToString();

                string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string saveDirectory = Path.Combine(currentDirectory, "RecipeImages");
                string fileSavePath = Path.Combine(saveDirectory, recipeInfo.RecipeImageName);
                if (File.Exists(fileSavePath))
                {
                    this.ImageName.Source = new BitmapImage(new Uri(fileSavePath));
                }
                else
                {
                }

                int totalAmount = 0;

                RecipeDescriptionTextBlock.Text = recipeInfo.Description;

                var ingredientsForRecipe = await _ingredientUnitRecipeService.GetIngredientUnitForRecipe(_recipeId);

                foreach (var eg in ingredientsForRecipe)
                {
                    var ingredientUnit = await _ingredientUnitService.GetIngredientUnitById(eg.IngredientUnitId);
                    if (ingredientUnit != null)
                    {
                        ListBoxItem ingredientUnitItem = new ListBoxItem
                        {
                            Content = $"{IngredientExtensions.GetDescription(ingredientUnit.Ingredient)} {ingredientUnit.Amount} {UnitExtensions.GetDescription(ingredientUnit.Unit)}",
                        };

                        ingredientUnitListBox.Items.Add(ingredientUnitItem);

                        totalAmount += 1;
                    }
                }
                IngredientsAmountTextBlock.Text = totalAmount.ToString();
            }
        }

        private void Account_Page(object sender, RoutedEventArgs e)
        {
            this._navigationService.NavigateTo<IAccountWindow>();
            this.Close();
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
