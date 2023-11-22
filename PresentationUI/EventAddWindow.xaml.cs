using MaterialDesignThemes.Wpf;
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
    /// Interaction logic for EventAddWindow.xaml
    /// </summary>
    public partial class EventAddWindow : Window
    {
        private readonly INavigationService _navigationService;
        public EventAddWindow(INavigationService navigationService)
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

        private List<ComboBox> comboBoxList = new List<ComboBox>();
        private List<Button> deleteButtonList = new List<Button>();
        private double verticalOffset = 300;

        private void AddGuestsButton_Click(object sender, RoutedEventArgs e)
        {
            ComboBox newComboBox = new ComboBox
            {
                Name = "GuestsInput" + comboBoxList.Count,
                Style = (Style)FindResource("MaterialDesignComboBox"),
                Width = 230,
                Height = 50,
                FontSize = 17,
                BorderThickness = new Thickness(0, 0, 0, 1.5),
                BorderBrush = new SolidColorBrush(Color.FromRgb(86, 90, 123)),
            };

            newComboBox.Items.Add(new ComboBoxItem { Content = "New Guest 1" });
            newComboBox.Items.Add(new ComboBoxItem { Content = "New Guest 2" });

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
                if (comboBoxList.Count > 0)
                {
                    int index = comboBoxList.Count - 1;
                    MyCanvas.Children.Remove(comboBoxList[index]);
                    MyCanvas.Children.Remove(deleteButtonList[index]);
                    comboBoxList.RemoveAt(index);
                    deleteButtonList.RemoveAt(index);

                    if (index < verticalOffset)
                    {
                        verticalOffset -= 70;
                    }
                }
            };

            Canvas.SetLeft(newComboBox, 80);
            Canvas.SetTop(newComboBox, verticalOffset);
            MyCanvas.Children.Add(newComboBox);

            Canvas.SetLeft(deleteButton, 25);
            Canvas.SetTop(deleteButton, verticalOffset + 20);
            MyCanvas.Children.Add(deleteButton);

            verticalOffset += 70;

            comboBoxList.Add(newComboBox);
            deleteButtonList.Add(deleteButton);
        }

        private List<ComboBox> comboBoxDishesList = new List<ComboBox>();
        private List<Button> deleteButtonDishesList = new List<Button>();
        private double verticalOffsetDishes = 300;

        private void AddDishesButton_Click(object sender, RoutedEventArgs e)
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

            newComboBox.Items.Add(new ComboBoxItem { Content = "New Guest 1" });
            newComboBox.Items.Add(new ComboBoxItem { Content = "New Guest 2" });
            newComboBox.Items.Add(new ComboBoxItem { Content = "New Guest 2" });
            newComboBox.Items.Add(new ComboBoxItem { Content = "New Guest 2" });
            newComboBox.Items.Add(new ComboBoxItem { Content = "New Guest 2" });

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
                if (comboBoxDishesList.Count > 0)
                {
                    int index = comboBoxDishesList.Count - 1;
                    MyCanvas.Children.Remove(comboBoxDishesList[index]);
                    MyCanvas.Children.Remove(deleteButtonDishesList[index]);
                    comboBoxDishesList.RemoveAt(index);
                    deleteButtonDishesList.RemoveAt(index);

                    if (index < verticalOffsetDishes)
                    {
                        verticalOffsetDishes -= 70;
                    }
                }
            };

            Canvas.SetLeft(newComboBox, 470);
            Canvas.SetTop(newComboBox, verticalOffsetDishes);
            MyCanvas.Children.Add(newComboBox);

            Canvas.SetLeft(deleteButton, 415);
            Canvas.SetTop(deleteButton, verticalOffsetDishes + 20);
            MyCanvas.Children.Add(deleteButton);

            verticalOffsetDishes += 70;

            comboBoxDishesList.Add(newComboBox);
            deleteButtonDishesList.Add(deleteButton);
        }
    }
}
