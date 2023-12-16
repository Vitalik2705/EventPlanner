namespace PresentationUI
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using BLL.Services.Interfaces;
    using DAL.Models;
    using DAL.State.Authenticator;
    using Microsoft.Win32;
    using PresentationUI.Interfaces;

    /// <summary>
    /// Interaction logic for RecipeAddWindow.xaml.
    /// </summary>
    public partial class RecipeAddWindow : Window, IRecipeAddWindow
    {
        private readonly IRecipeService _recipeService;
        private readonly INavigationService _navigationService;
        private readonly IIngredientUnitService _ingredientUnitService;
        private readonly IAuthenticator _authenticator;
        private List<ComboBox> comboBoxIngredientsList = new List<ComboBox>();
        private List<ComboBox> comboBoxUnitsList = new List<ComboBox>();
        private List<TextBox> textBoxAmountOfUnitList = new List<TextBox>();
        private List<Button> deleteButtonIngredientsList = new List<Button>();
        private double verticalOffsetIngredients = 190;

        private OpenFileDialog openFileDialog;

        /// <summary>
        /// Initializes a new instance of the <see cref="RecipeAddWindow"/> class.
        /// </summary>
        /// <param name="navigationService">navigationService.</param>
        public RecipeAddWindow(IRecipeService recipeService, INavigationService navigationService, IIngredientUnitService
            ingredientUnitService, IAuthenticator authenticator)
        {
            this._recipeService = recipeService;
            this._navigationService = navigationService;
            this._ingredientUnitService = ingredientUnitService;
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

        private void AddIngredientsButton_Click(object sender, RoutedEventArgs e)
        {
            ComboBox newComboBox = new ComboBox
            {
                Name = "IngredientInput" + this.comboBoxIngredientsList.Count,
                Style = (Style)this.FindResource("MaterialDesignComboBox"),
                Width = 230,
                Height = 50,
                FontSize = 17,
                BorderThickness = new Thickness(0, 0, 0, 1.5),
                BorderBrush = new SolidColorBrush(Color.FromRgb(86, 90, 123)),
                IsEditable = true,
                IsTextSearchEnabled = true,
            };

            Type enumIngredientType = typeof(Ingredient);
            Array enumIngredientValues = Enum.GetValues(enumIngredientType);

            foreach (var enumValue in enumIngredientValues)
            {
                string description = IngredientExtensions.GetDescription((Ingredient)enumValue);
                ComboBoxItem item = new ComboBoxItem
                {
                    Content = description,
                    Tag = enumValue // You can use Tag property to store the enum value if needed
                };

                newComboBox.Items.Add(item);
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

            ComboBox newComboBoxUnit = new ComboBox
            {
                Name = "UnitsInput" + this.comboBoxIngredientsList.Count,
                Style = (Style)this.FindResource("MaterialDesignComboBox"),
                Width = 105,
                Height = 50,
                FontSize = 17,
                BorderThickness = new Thickness(0, 0, 0, 1.5),
                BorderBrush = new SolidColorBrush(Color.FromRgb(86, 90, 123)),
                IsEditable = true,
                IsTextSearchEnabled = true,
            };

            Type enumUnitType = typeof(Unit);
            Array enumUnitValues = Enum.GetValues(enumUnitType);

            foreach (var enumValue in enumUnitValues)
            {
                string description = UnitExtensions.GetDescription((Unit)enumValue);
                ComboBoxItem item = new ComboBoxItem
                {
                    Content = description,
                    Tag = enumValue
                };

                newComboBoxUnit.Items.Add(item);
            }

            TextBox newTextBoxAmount = new TextBox
            {
                Name = "AmountOfUnitInput" + this.comboBoxIngredientsList.Count,
                Style = (Style)this.FindResource("MaterialDesignFloatingHintTextBox"),
                Width = 105,
                Height = 50,
                FontSize = 17,
                BorderThickness = new Thickness(0, 0, 0, 1.5),
                BorderBrush = new SolidColorBrush(Color.FromRgb(86, 90, 123)),
            };

            deleteButton.Click += (s, args) =>
            {
                if (this.comboBoxIngredientsList.Count > 0)
                {
                    int index = this.comboBoxIngredientsList.Count - 1;
                    this.MyCanvas.Children.Remove(this.comboBoxIngredientsList[index]);
                    this.MyCanvas.Children.Remove(this.deleteButtonIngredientsList[index]);
                    this.MyCanvas.Children.Remove(this.comboBoxUnitsList[index]);
                    this.MyCanvas.Children.Remove(this.textBoxAmountOfUnitList[index]);
                    this.comboBoxIngredientsList.RemoveAt(index);
                    this.deleteButtonIngredientsList.RemoveAt(index);
                    this.comboBoxUnitsList.RemoveAt(index);
                    this.textBoxAmountOfUnitList.RemoveAt(index);

                    if (index < this.verticalOffsetIngredients)
                    {
                        this.verticalOffsetIngredients -= 120;
                    }
                }
            };

            Canvas.SetLeft(newComboBox, 470);
            Canvas.SetTop(newComboBox, this.verticalOffsetIngredients);
            this.MyCanvas.Children.Add(newComboBox);

            Canvas.SetLeft(deleteButton, 415);
            Canvas.SetTop(deleteButton, this.verticalOffsetIngredients + 20);
            this.MyCanvas.Children.Add(deleteButton);

            Canvas.SetLeft(newComboBoxUnit, 470);
            Canvas.SetTop(newComboBoxUnit, this.verticalOffsetIngredients + 60);
            this.MyCanvas.Children.Add(newComboBoxUnit);

            Canvas.SetLeft(newTextBoxAmount, 600);
            Canvas.SetTop(newTextBoxAmount, this.verticalOffsetIngredients + 60);
            this.MyCanvas.Children.Add(newTextBoxAmount);

            this.verticalOffsetIngredients += 120;

            this.comboBoxIngredientsList.Add(newComboBox);
            this.deleteButtonIngredientsList.Add(deleteButton);
            this.comboBoxUnitsList.Add(newComboBoxUnit);
            this.textBoxAmountOfUnitList.Add(newTextBoxAmount);
        }

        private void SelectImage_Click(object sender, RoutedEventArgs e)
        {
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Файли зображень (*.jpg; *.jpeg; *.png)|*.jpg;*.jpeg;*.png|Всі файли (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                // Отримайте шлях до обраного файлу
                string selectedImagePath = openFileDialog.FileName;

                // Відображення зображення в елементі Image
                this.SelectedImage.Source = new BitmapImage(new Uri(selectedImagePath));
            }
        }

        private async void AddRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            var nameRecipe = this.RecipeNameInput.Text;
            var caloriesText = this.AmountOfCaloriesInput.Text;
            string hoursText = this.HoursComboBox.Text;
            string minutesText = this.MinutesComboBox.Text;

            int calories = int.TryParse(caloriesText, out int parsedCalories) ? parsedCalories : 0;
            int hours = int.TryParse(hoursText, out int parsedHours) ? parsedHours : 0;
            int minutes = int.TryParse(minutesText, out int parsedMinutes) ? parsedMinutes : 0;

            int totalMinutes = (hours * 60) + minutes;

            var image = "";

            if (openFileDialog != null)
            {
                string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string saveDirectory = Path.Combine(currentDirectory, "RecipeImages");
                image = Path.GetFileName(openFileDialog.FileName);
                string fileSavePath = Path.Combine(saveDirectory, image);
                if (!Directory.Exists(saveDirectory))
                {
                    Directory.CreateDirectory(saveDirectory);
                }

                File.Copy(openFileDialog.FileName, fileSavePath, true);
            }

            var recipeGR = new Recipe()
            {
                Name = nameRecipe,
                Calories = calories,
                CookingTime = totalMinutes,
                CreatedDate = DateTime.UtcNow,
                RecipeImageName = image,
            };

            await this._recipeService.AddRecipe(recipeGR);

            var ingredientUnits = new List<IngredientUnit>();
            for (int i = 0; i < comboBoxIngredientsList.Count; i++)
            {
                var ingredient = IngredientExtensions.GetEnumValueFromDescription(comboBoxIngredientsList[i].Text);
                var unit = UnitExtensions.GetEnumValueFromDescription(comboBoxUnitsList[i].Text);
                var amount = Convert.ToInt32(textBoxAmountOfUnitList[i].Text);

                var ingredientUnit = new IngredientUnit
                {
                    Ingredient = ingredient,
                    Unit = unit,
                    Amount = amount,
                };

                await this._ingredientUnitService.AddIngredientUnit(ingredientUnit);
            }

            this._navigationService.NavigateTo<IRecipeListWindow>();
            this.Close();
        }

        private void ___images_icons8_logout_50_png_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this._authenticator.Logout();

            this._navigationService.NavigateTo<IMainWindow>();
            this.Close();
        }
    }
}
