// <copyright file="RegisterWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PresentationUI
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media.Imaging;
    using BLL.Services.Interfaces;
    using DAL.Models;
    using DAL.State.Authenticator;
    using Microsoft.Extensions.Logging;
    using Microsoft.Win32;

    /// <summary>
    /// Interaction logic for Register.xaml.
    /// </summary>
    public partial class RegisterWindow : Window, IRegisterWindow
    {
        private readonly IAuthenticator _authenticator;
        private readonly INavigationService _navigationService;
        private readonly ILogger<RegisterWindow> _registerLogger;
        private OpenFileDialog openFileDialog;

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

        private async void Register_Click(object sender, RoutedEventArgs e)
        {
            this._registerLogger.LogInformation("Attempting to register the account.");

            var email = this.EmailInput.Text;
            var password = this.PasswordInput.Password;
            var name = this.FirstnameInput.Text;
            var surname = this.LastnameInput.Text;
            var phoneNumber = this.PhoneNumberInput.Text;
            var selectedComboBoxItem = (ComboBoxItem)GenderItem.SelectedItem;
            string selectedSex = selectedComboBoxItem.Content.ToString();
            var gender = selectedSex != "Чоловік" ? Gender.Female : Gender.Male;
            
            var image = "";

            if (openFileDialog != null)
            {
                string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string saveDirectory = Path.Combine(currentDirectory, "UserImages");
                image = Path.GetFileName(openFileDialog.FileName);
                string fileSavePath = Path.Combine(saveDirectory, image);
                if (!Directory.Exists(saveDirectory))
                {
                    Directory.CreateDirectory(saveDirectory);
                }

                File.Copy(openFileDialog.FileName, fileSavePath, true);
            }
            else
            {
                image = gender == Gender.Female ? "avatar_woman.jpg" : "avatar_man.jpg";
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
                UserImageName = image,
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
            }
            catch (Exception ex)
            {
                this._registerLogger.LogError($"Failed to register the account. {ex}");
            }
        }

        private void AddPhotoButton_Click(object sender, RoutedEventArgs e)
        {
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Файли зображень (*.jpg; *.jpeg; *.png)|*.jpg;*.jpeg;*.png|Всі файли (*.*)|*.*";

            //string saveDirectory = "RecipesImages/";

            if (openFileDialog.ShowDialog() == true)
            {
                // Отримайте шлях до обраного файлу
                string selectedImagePath = openFileDialog.FileName;

                // Відображення зображення в елементі Image
                this.SelectedImage.Source = new BitmapImage(new Uri(selectedImagePath));
            }
        }
    }
}
