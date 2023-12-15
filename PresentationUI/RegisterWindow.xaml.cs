// <copyright file="RegisterWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PresentationUI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Windows;
    using System.Windows.Media;
    using BLL.Services.Interfaces;
    using DAL.Models;
    using DAL.State.Authenticator;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Interaction logic for Register.xaml.
    /// </summary>
    public partial class RegisterWindow : Window, IRegisterWindow
    {
        private readonly IAuthenticator _authenticator;
        private readonly INavigationService _navigationService;
        private readonly ILogger<RegisterWindow> _registerLogger;

#pragma warning disable SA1614 // Element parameter documentation should have text
        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterWindow"/> class.
        /// </summary>
        /// <param name="userService"></param>
        public RegisterWindow(IAuthenticator authenticator, INavigationService navigationService, ILogger<RegisterWindow> registerLogger)
#pragma warning restore SA1614 // Element parameter documentation should have text
        {
            this._navigationService = navigationService;
            this._authenticator = authenticator;
            this._registerLogger = registerLogger;
            this.InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            this._navigationService.NavigateTo<ILoginWindow>();
            this.Close();
        }

        private bool ValidateEmail(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
            Regex regex = new Regex(emailPattern);
            return regex.IsMatch(email);
        }

        private bool ValidatePassword(string password)
        {
            if (string.IsNullOrEmpty(password) || password.Length < 8)
            {
                return false;
            }

            bool hasUppercase = false;
            bool hasLowercase = false;
            bool hasDigit = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c))
                {
                    hasUppercase = true;
                }
                else if (char.IsLower(c))
                {
                    hasLowercase = true;
                }
                else if (char.IsDigit(c))
                {
                    hasDigit = true;
                }
            }

            return hasUppercase && hasLowercase && hasDigit;
        }


        private bool ValidateName(string name)
        {
            return !string.IsNullOrEmpty(name) && name.All(char.IsLetter);
        }

        private bool ValidatePhoneNumber(string phoneNumber)
        {
            string phonePattern = @"^0\d{9}$";
            Regex regex = new Regex(phonePattern);
            return !string.IsNullOrEmpty(phoneNumber) && regex.IsMatch(phoneNumber);
        }

        private bool ValidateGender(Gender gender)
        {
            return !string.IsNullOrEmpty(gender.ToString());
        }

        private async void Register_Click(object sender, RoutedEventArgs e)
        {
            this._registerLogger.LogInformation("Attempting to register the account.");

            var email = this.EmailInput.Text;
            var password = this.PasswordInput.Password;
            var name = this.FirstnameInput.Text;
            var surname = this.LastnameInput.Text;
            var phoneNumber = this.PhoneNumberInput.Text;
            var selectedGenderItem = this.GenderItem.SelectedItem;
            var gender = (selectedGenderItem != null && selectedGenderItem.ToString() != "Чоловік") ? Gender.Female : Gender.Male;

            bool isAnyFieldInvalid =
                selectedGenderItem == null ||
                !ValidateEmail(email) ||
                !ValidatePassword(password) ||
                !ValidateName(name) ||
                !ValidateName(surname) ||
                !ValidatePhoneNumber(phoneNumber) ||
                !ValidateGender(gender);

            this.EmailInput.BorderBrush = ValidateEmail(email) ? Brushes.Black : Brushes.Red;
            this.PasswordInput.BorderBrush = ValidatePassword(password) ? Brushes.Black : Brushes.Red;
            this.FirstnameInput.BorderBrush = ValidateName(name) ? Brushes.Black : Brushes.Red;
            this.LastnameInput.BorderBrush = ValidateName(surname) ? Brushes.Black : Brushes.Red;
            this.PhoneNumberInput.BorderBrush = ValidatePhoneNumber(phoneNumber) ? Brushes.Black : Brushes.Red;
            this.GenderItem.BorderBrush = (selectedGenderItem != null && ValidateGender(gender)) ? Brushes.Black : Brushes.Red; // Assumes GenderItem is a ComboBox

            if (isAnyFieldInvalid)
            {
                return;
            }


            User user = new User()
            {
                Surname = surname,
                Name = name,
                PhoneNumber = phoneNumber,
                Email = email,
                Password = password,
                Events = new List<Event>(),
                Gender = gender,
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = null,
                UserImage = null,
            };
            try
            {
                var userReg = await this._authenticator.Register(user);

                if (userReg == BLL.Services.Repositories.IUserRepository.RegistrationResult.Success)
                {
                    this._registerLogger.LogInformation("Successfully register the account.");

                    this._navigationService.NavigateTo<ILoginWindow>();
                    this.Close();
                }
                if (userReg == BLL.Services.Repositories.IUserRepository.RegistrationResult.EmailAlreadyExists)
                {
                    ShowErrorMessage("Користувач з таким email-ом вже існує.");
                }
            }
            catch (Exception ex)
            {
                
                this._registerLogger.LogError($"Failed to register the account. {ex}");
            }
        }

        private void ShowErrorMessage(string errorMessage)
        {
            // You can implement the logic to display the error message to the user here.
            // For example, show a MessageBox or update a UI element with the error message.
            MessageBox.Show(errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
