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
    /// Interaction logic for RecipeListWindow.xaml
    /// </summary>
    public partial class RecipeListWindow : Window
    {
        public RecipeListWindow()
        {
            InitializeComponent();
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

        private void Add_Recipe_Click(object sender, RoutedEventArgs e)
        {
            GuestAddWindow secondWindow = new GuestAddWindow();
            secondWindow.Show();
            this.Close();
        }

        private void Events_Click(object sender, RoutedEventArgs e)
        {
            EventListWindow secondWindow = new EventListWindow();
            secondWindow.Show();
            this.Close();
        }

        private void Guests_Click(object sender, RoutedEventArgs e)
        {
            GuestListWindow secondWindow = new GuestListWindow();
            secondWindow.Show();
            this.Close();
        }

        private void Recipes_Click(object sender, RoutedEventArgs e)
        {
            RecipeListWindow secondWindow = new RecipeListWindow();
            secondWindow.Show();
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
