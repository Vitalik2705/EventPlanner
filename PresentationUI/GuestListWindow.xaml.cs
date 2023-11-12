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
    /// Interaction logic for GuestListWindow.xaml
    /// </summary>
    public partial class GuestListWindow : Window
    {
        public GuestListWindow()
        {
            InitializeComponent();
        }

        private void Account_Page(object sender, RoutedEventArgs e)
        {
            //AccountWindow secondWindow = new AccountWindow();
            //secondWindow.Show();
            //this.Close();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            //AccountWindow secondWindow = new AccountWindow();
            //secondWindow.Show();
            //this.Close();
        }

        private void Add_Guest_Click(object sender, RoutedEventArgs e)
        {
            //AccountWindow secondWindow = new AccountWindow();
            //secondWindow.Show();
            //this.Close();
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = searchTextBox.Text.ToLower();

            // Проходження через елементи списку та виконання пошуку
            foreach (var item in itemListBox.Items)
            {
                if (item is ListBoxItem listBoxItem)
                {
                    // Знаходження StackPanel в ListBoxItem
                    var stackPanel = FindVisualChild<StackPanel>(listBoxItem);

                    if (stackPanel != null)
                    {
                        // Знаходження TextBlock в StackPanel
                        var textBlock = FindVisualChild<TextBlock>(stackPanel);

                        if (textBlock != null)
                        {
                            // Отримання текстового представлення TextBlock
                            string itemText = textBlock.Text.ToLower();

                            // Додайте вашу логіку порівняння з searchText тут
                            // Наприклад, якщо назва елемента містить searchText, то робіть його видимим
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

        // Допоміжний метод для знаходження дочірніх елементів визначеного типу
        private T FindVisualChild<T>(DependencyObject parent) where T : DependencyObject
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
                    T childOfChild = FindVisualChild<T>(child);

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
