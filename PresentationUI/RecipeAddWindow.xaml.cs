namespace PresentationUI
{
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using Microsoft.Win32;

    /// <summary>
    /// Interaction logic for RecipeAddWindow.xaml.
    /// </summary>
    public partial class RecipeAddWindow : Window
    {
        private readonly INavigationService _navigationService;
        private List<ComboBox> comboBoxIngredientsList = new List<ComboBox>();
        private List<ComboBox> comboBoxUnitsList = new List<ComboBox>();
        private List<TextBox> textBoxAmountOfUnitList = new List<TextBox>();
        private List<Button> deleteButtonIngredientsList = new List<Button>();
        private double verticalOffsetIngredients = 310;

        /// <summary>
        /// Initializes a new instance of the <see cref="RecipeAddWindow"/> class.
        /// </summary>
        /// <param name="navigationService">navigationService.</param>
        public RecipeAddWindow(INavigationService navigationService)
        {
            this._navigationService = navigationService;
            this.InitializeComponent();
        }

        private void Guests_Click(object sender, RoutedEventArgs e)
        {
            this._navigationService.NavigateTo<IGuestListWindow>();
            this.Close();
        }

        private void Events_Click(object sender, RoutedEventArgs e)
        {
            EventListWindow secondWindow = new EventListWindow(this._navigationService);
            secondWindow.Show();
            this.Close();
        }

        private void Recipes_Click(object sender, RoutedEventArgs e)
        {
            RecipeListWindow secondWindow = new RecipeListWindow(this._navigationService);
            secondWindow.Show();
            this.Close();
        }

        private void AddIngredientsButton_Click(object sender, RoutedEventArgs e)
        {
            ComboBox newComboBox = new ComboBox
            {
                Name = "GuestsInput" + this.comboBoxIngredientsList.Count,
                Style = (Style)this.FindResource("MaterialDesignComboBox"),
                Width = 230,
                Height = 50,
                FontSize = 17,
                BorderThickness = new Thickness(0, 0, 0, 1.5),
                BorderBrush = new SolidColorBrush(Color.FromRgb(86, 90, 123)),
            };

            newComboBox.Items.Add(new ComboBoxItem { Content = "Тісто" });
            newComboBox.Items.Add(new ComboBoxItem { Content = "Ковбаса" });
            newComboBox.Items.Add(new ComboBoxItem { Content = "Соус" });
            newComboBox.Items.Add(new ComboBoxItem { Content = "Сир" });

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
            };

            newComboBoxUnit.Items.Add(new ComboBoxItem { Content = "кг" });
            newComboBoxUnit.Items.Add(new ComboBoxItem { Content = "шт" });
            newComboBoxUnit.Items.Add(new ComboBoxItem { Content = "г" });

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
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Файли зображень (*.jpg; *.jpeg; *.png)|*.jpg;*.jpeg;*.png|Всі файли (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                // Отримайте шлях до обраного файлу
                string selectedImagePath = openFileDialog.FileName;

                // Відображення зображення в елементі Image
                this.SelectedImage.Source = new BitmapImage(new Uri(selectedImagePath));
            }
        }
    }
}
