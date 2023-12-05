// <copyright file="ChangePasswordWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PresentationUI
{
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

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangePasswordWindow"/> class.
        /// </summary>
        /// <param name="navigationService">.</param>
        public ChangePasswordWindow(INavigationService navigationService)
        {
            this._navigationService = navigationService;
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
            bool hasMinLength = newPassword.Length >= 10;
            bool hasLettersAndDigits = Regex.IsMatch(newPassword, @"^[a-zA-Z0-9]+$");

            bool passwordsMatch = string.Equals(newPassword, repeatPassword);

            this.SetPasswordConditionText(this.PasswordConditionsTextUppercase, "Як мінімум 1 велика літера є обов'язковою.", hasUpperCase);
            this.SetPasswordConditionText(this.PasswordConditionsTextLength, "Мінімальна довжина 10 символів.", hasMinLength);
            this.SetPasswordConditionText(this.PasswordConditionsTextChars, "Тільки латинські літери та цифри дозволені.", hasLettersAndDigits);
            this.SetPasswordConditionText(this.PasswordConditionsTextPasswordsMatch, "Паролі не співпадають.", passwordsMatch);
        }
    }
}