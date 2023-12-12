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

        private void ChangePasswordPage_click(object sender, RoutedEventArgs e)
        {
            this._navigationService.NavigateTo<IChangePasswordWindow>();
            this.Close();
        }
        

        private async void ChangeCredentials_Click(object sender, RoutedEventArgs e)
        {
            string newEmail = this.NewEmailInput.Text;
            string newPhone = this.NewPhoneInput.Text;

            var userValidator = new RegisterValidation();

            User user = this._authenticator.CurrentUser;
            User temp = user;

            if (NewEmailInput.Text == "" && NewPhoneInput.Text != "")
            {
                temp.PhoneNumber = newPhone;
            }
            if (NewEmailInput.Text != "" && NewPhoneInput.Text == "")
            {
                temp.Email = newEmail;
            }
            if (NewEmailInput.Text != "" && NewPhoneInput.Text != "")
            {
                temp.PhoneNumber = newPhone;
                temp.Email = newEmail;
            }
            if (NewEmailInput.Text == "" && NewPhoneInput.Text == "")
            {
                return;
            }

            var emailValidationResult = userValidator.Validate(temp);
            if (!emailValidationResult.IsValid)
            {
                MessageBox.Show($"Invalid email:\n{string.Join(Environment.NewLine, emailValidationResult.Errors)}");
                return;
            }

            var phoneValidationResult = userValidator.Validate(temp);
            if (!phoneValidationResult.IsValid)
            {
                MessageBox.Show($"Invalid phone:\n{string.Join(Environment.NewLine, phoneValidationResult.Errors)}");
                return;
            }

            if (!string.IsNullOrEmpty(newEmail))
            {
                user.Email = newEmail;
            }

            if (!string.IsNullOrEmpty(newPhone))
            {
                user.PhoneNumber = newPhone;
            }

            await this._userService.UpdateUser(user);

            this.Email.Text = user.Email;
            this.Phone.Text = user.PhoneNumber;

            this.NewEmailInput.Clear();
            this.NewPhoneInput.Clear();

        }

        private void ___images_icons8_logout_50_png_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this._authenticator.Logout();

            this._navigationService.NavigateTo<IMainWindow>();
            this.Close();
        }
    }
}
