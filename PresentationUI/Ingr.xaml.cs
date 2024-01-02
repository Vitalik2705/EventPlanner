using BLL.Services.Interfaces;
using DAL.Models;
using DAL.State.Authenticator;
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
    /// Interaction logic for IngredientAdd.xaml
    /// </summary>
    public partial class Ingr : Window, IIngredientNew
    {
        private readonly INavigationService _navigationService;
        private readonly IAuthenticator _authenticator;
        private readonly IIngredientNewService _ingredientNewService;
        public Ingr(INavigationService navigationService, IAuthenticator authenticator, IIngredientNewService ingredientNewService)
        {
            this._navigationService = navigationService;
            this._authenticator = authenticator;
            this._ingredientNewService = ingredientNewService;
            InitializeComponent();
        }

        private void Guests_Click(object sender, RoutedEventArgs e)
        {
            this._navigationService.NavigateTo<IGuestListWindow>();
            this.Close();
        }

        private void Events_Click(object sender, RoutedEventArgs e)
        {
            this._navigationService.NavigateTo<IEventListWindow>();
            this.Close();
        }

        private void Recipes_Click(object sender, RoutedEventArgs e)
        {
            this._navigationService.NavigateTo<IRecipeListWindow>();
            this.Close();
        }
        private void Account_Click(object sender, RoutedEventArgs e)
        {
            this._navigationService.NavigateTo<IAccountWindow>();
            this.Close();
        }
        private async void AddGuest_Click(object sender, RoutedEventArgs e)
        {
            var name = this.FirstNameInput.Text;

            //if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname))
            //{
            //    ShowErrorMessage("Гість повинен мати не порожнє ім'я та прізвище");
            //    return;
            //}

            DAL.Models.IngredientNew ingredientNew = new DAL.Models.IngredientNew()
            {
                Name = name,
            };
            try
            {
                await this._ingredientNewService.AddIngredientNew(ingredientNew);

                // AccountWindow secondWindow = new AccountWindow(userReg);
                //this._navigationService.NavigateTo<IGuestListWindow>();
                //this.Close();
            }
            catch (Exception ex)
            {
            }
        }
    }
}
