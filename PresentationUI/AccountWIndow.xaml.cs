// <copyright file="AccountWIndow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PresentationUI
{
    using System;
    using System.Windows;
    using BLL.Services.Interfaces;
    using BLL.Validation;
    using DAL.Models;
    using DAL.State.Authenticator;
    using PresentationUI.Interfaces;

    /// <summary>
    /// Interaction logic for AccountWIndow.xaml.
    /// </summary>
    public partial class AccountWindow : Window, IAccountWindow
    {
        private readonly INavigationService _navigationService;
        private readonly IAuthenticator _authenticator;
        private readonly IUserService _userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountWindow"/> class.
        /// </summary>
        /// <param name="user">name.</param>
        public AccountWindow(IAuthenticator authenticator, INavigationService navigationService, IUserService userService)
        {
            this._navigationService = navigationService;
            this._authenticator = authenticator;
            this._userService = userService;
            User user = this._authenticator.CurrentUser;
            this.InitializeComponent();
            string userName = $"{user.Surname} {user.Name}";
            this.UserName.Text = userName;
            this.Email.Text = user.Email;
            this.Phone.Text = user.PhoneNumber;
        }

        private void Guest_Page(object sender, RoutedEventArgs e)
        {
            this._navigationService.NavigateTo<IGuestListWindow>();
            this.Close();
        }

        private void Events_Page(object sender, RoutedEventArgs e)
        {
            this._navigationService.NavigateTo<IEventListWindow>();
            this.Close();
        }

        private void Recipes_Page(object sender, RoutedEventArgs e)
        {
            this._navigationService.NavigateTo<IRecipeListWindow>();
            this.Close();
        }

        private async void ChangeCredentials_Click(object sender, RoutedEventArgs e)
        {
            string newEmail = this.NewEmailInput.Text;
            string newPassword = this.NewPasswordInput.Password;

            //var userValidator = new RegisterValidation();

            //var tempUser = new User
            //{
            //    Name = "ddd",
            //    Surname = "ddd",
            //    Email = newEmail,
            //    Password = newPassword,
            //    PhoneNumber = "0123456789",
            //};

            //var emailValidationResult = userValidator.Validate(tempUser);
            //if (!emailValidationResult.IsValid)
            //{
            //    MessageBox.Show($"Invalid email: {string.Join(Environment.NewLine, emailValidationResult.Errors)}");
            //    return;
            //}

            //var passwordValidationResult = userValidator.Validate(tempUser);
            //if (!passwordValidationResult.IsValid)
            //{
            //    MessageBox.Show($"Invalid password: {string.Join(Environment.NewLine, passwordValidationResult.Errors)}");
            //    return;
            //}

            User user = this._authenticator.CurrentUser;

            if (!string.IsNullOrEmpty(newEmail))
            {
                user.Email = newEmail;
            }

            if (!string.IsNullOrEmpty(newPassword))
            {
                user.Password = newPassword;
            }

            await this._userService.UpdateUser(user);

            this.Email.Text = user.Email;

            this.NewEmailInput.Clear();
            this.NewPasswordInput.Clear();
        }
    }
}
