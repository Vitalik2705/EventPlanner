// <copyright file="AccountWIndow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PresentationUI
{
    using System.Windows;
    using DAL.Models;
    using DAL.State.Authenticator;

    /// <summary>
    /// Interaction logic for AccountWIndow.xaml.
    /// </summary>
    public partial class AccountWindow : Window, IAccountWindow
    {
        private readonly INavigationService _navigationService;
        private readonly IAuthenticator _authenticator;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountWindow"/> class.
        /// </summary>
        /// <param name="user">name.</param>
        public AccountWindow(IAuthenticator authenticator, INavigationService navigationService)
        {
            this._navigationService = navigationService;
            this._authenticator = authenticator;
            User user = this._authenticator.CurrentUser;
            this.InitializeComponent();
            string userName = $"{user.Surname} {user.Name}";
            this.UserName.Text = userName;
            this.Email.Text = user.Email;
            this.Phone.Text = user.PhoneNumber;
        }

        private void Guest_Page(object sender, RoutedEventArgs e)
        {
            _navigationService.NavigateTo<IGuestListWindow>();
            this.Close();
        }
        private void Events_Page(object sender, RoutedEventArgs e)
        {
            EventListWindow secondWindow = new EventListWindow(_navigationService);
            secondWindow.Show();
            this.Close();
        }

        private void Recipes_Page(object sender, RoutedEventArgs e)
        {
            RecipeListWindow secondWindow = new RecipeListWindow(_navigationService);
            secondWindow.Show();
            this.Close();
        }
    }
}
