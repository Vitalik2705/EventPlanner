// <copyright file="ChangePasswordWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PresentationUI
{
    using BCrypt.Net;
    using BLL.Services.Interfaces;
    using BLL.Validation;
    using DAL.State.Authenticator;
    using PresentationUI.Interfaces;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;


    /// <summary>
    /// Interaction logic for EventListWindow.xaml.
    /// </summary>
    public partial class ChangePasswordWindow : Window, IChangePasswordWindow
    {
        private readonly INavigationService _navigationService;
        private readonly IAuthenticator _authenticator;
        private readonly IUserService _userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangePasswordWindow"/> class.
        /// </summary>
        /// <param name="navigationService">.</param>
        public ChangePasswordWindow(IAuthenticator authenticator, INavigationService navigationService, IUserService userService)
        {
            this._navigationService = navigationService;
            this._authenticator = authenticator;
            this._userService = userService;
            this.InitializeComponent();
        }

        private void Account_Page(object sender, RoutedEventArgs e)
        {
            this._navigationService.NavigateTo<IAccountWindow>();
            this.Close();
        }

        private void Guests_Click(object sender, RoutedEventArgs e)
        {
            this._navigationService.NavigateTo<IGuestListWindow>();
            this.Close();
        }

        private void Recipes_Click(object sender, RoutedEventArgs e)
        {
            this._navigationService.NavigateTo<IRecipeListWindow>();
            this.Close();
        }

        private void SetPasswordConditionText(TextBlock textBlock, string conditionText, bool conditionMet)
        {
            textBlock.Text = "\u2022 " + conditionText + "\n";
            textBlock.Foreground = conditionMet ? Brushes.Green : Brushes.Red;
        }

        private void PasswordInput_PasswordChanged(object sender, RoutedEventArgs e)
        {
            string newPassword = this.NewPasswordInput.Password;
            string repeatPassword = this.RepeatPasswordInput.Password;

            bool hasUpperCase = newPassword.Any(char.IsUpper);
            bool hasMinLength = newPassword.Length >= 8;
            bool hasLettersAndDigits = Regex.IsMatch(newPassword, @"^[a-zA-Z0-9]+$");

            bool passwordsMatch = string.Equals(newPassword, repeatPassword);

            this.SetPasswordConditionText(this.PasswordConditionsTextUppercase, "Як мінімум 1 велика літера є обов'язковою.", hasUpperCase);
            this.SetPasswordConditionText(this.PasswordConditionsTextLength, "Мінімальна довжина 8 символів.", hasMinLength);
            this.SetPasswordConditionText(this.PasswordConditionsTextChars, "Тільки латинські літери та цифри дозволені.", hasLettersAndDigits);
            this.SetPasswordConditionText(this.PasswordConditionsTextPasswordsMatch, "Паролі співпадають.", passwordsMatch);

            if (hasUpperCase && hasMinLength && hasLettersAndDigits && passwordsMatch)
            {
                AddEventButton.IsEnabled = true;
            }
        }

        private async void AddEventButton_Click(object sender, RoutedEventArgs e)
        {
            var user = this._authenticator.CurrentUser;
            user.Password = NewPasswordInput.Password;
            string hashedPassword = BCrypt.HashPassword(user.Password);

            user.Password = hashedPassword;
            var registerValidation = new RegisterValidation();

            var userValidation = registerValidation.Validate(user);
            if(userValidation.IsValid)
            {
                await this._userService.UpdateUser(user);
            }

            this._navigationService.NavigateTo<IAccountWindow>();
            this.Close();
        }
    }
}