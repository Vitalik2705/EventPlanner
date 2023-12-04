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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PresentationUI
{
    /// <summary>
    /// Interaction logic for OpportunitiesWindow.xaml
    /// </summary>
    public partial class OpportunitiesWindow : Window
    {
        private readonly INavigationService _navigationService;
        public OpportunitiesWindow(INavigationService navigationService)
        {
            this._navigationService = navigationService;
            InitializeComponent();
        }
        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            this._navigationService.NavigateTo<IOpportunitiesWindow>();
            this.Hide();
        }
    }
}
