using Microsoft.Win32;
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
    /// Interaction logic for RecipeAddWindow.xaml
    /// </summary>
    public partial class RecipeAddWindow : Window
    {
        private readonly INavigationService _navigationService;
        private List<ComboBox> comboBoxIngredientsList = new List<ComboBox>();
        private List<Button> deleteButtonIngredientsList = new List<Button>();
        private double verticalOffsetIngredients = 255;

        public RecipeAddWindow(INavigationService navigationService)
        {
            _navigationService = navigationService;
            InitializeComponent();
        }

        private void Guests_Click(object sender, RoutedEventArgs e)
        {
            _navigationService.NavigateTo<IGuestListWindow>();
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

        private void AddIngredientsButton_Click(object sender, RoutedEventArgs e)
        {
            ComboBox newComboBox = new ComboBox
            {
                Name = "GuestsInput" + comboBoxIngredientsList.Count,
                Style = (Style)FindResource("MaterialDesignComboBox"),
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
                    Source = new BitmapImage(new Uri("images/plus (1).png", UriKind.Relative))
                },
            };

            deleteButton.Click += (s, args) =>
            {
                if (comboBoxIngredientsList.Count > 0)
                {
                    int index = comboBoxIngredientsList.Count - 1;
                    MyCanvas.Children.Remove(comboBoxIngredientsList[index]);
                    MyCanvas.Children.Remove(deleteButtonIngredientsList[index]);
                    comboBoxIngredientsList.RemoveAt(index);
                    deleteButtonIngredientsList.RemoveAt(index);

                    if (index < verticalOffsetIngredients)
                    {
                        verticalOffsetIngredients -= 70;
                    }
                }
            };

            Canvas.SetLeft(newComboBox, 470);
            Canvas.SetTop(newComboBox, verticalOffsetIngredients);
            MyCanvas.Children.Add(newComboBox);

            Canvas.SetLeft(deleteButton, 415);
            Canvas.SetTop(deleteButton, verticalOffsetIngredients + 20);
            MyCanvas.Children.Add(deleteButton);

            verticalOffsetIngredients += 70;

            comboBoxIngredientsList.Add(newComboBox);
            deleteButtonIngredientsList.Add(deleteButton);
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
                SelectedImage.Source = new BitmapImage(new Uri(selectedImagePath));
            }
        }
    }
}
