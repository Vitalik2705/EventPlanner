using PresentationUI.Interfaces;
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
    /// Interaction logic for EventListWindow.xaml
    /// </summary>
    public partial class EventListWindow : Window, IEventListWindow
    {
        private readonly INavigationService _navigationService;
        public EventListWindow(INavigationService navigationService)
        {
            _navigationService = navigationService;
            InitializeComponent();
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
            this._navigationService.NavigateTo<RecipeListWindow>();
            this.Close();
        }

        private void Add_Event_Click(object sender, RoutedEventArgs e)
        {
            this._navigationService.NavigateTo<EventAddWindow>();
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
    }
}

