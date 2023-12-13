using CommunityToolkit.Maui.Core;
using ProductoApp.Models;
using ProductoApp.Services;
using Microsoft.Maui.Controls;
using System;
using System.Linq;
using ProductoApp.Services;
using ProductoApp;
using ProductoApp.Models;

namespace ProductoApp
{
    public partial class LoginPage : ContentPage
    {
        private User _usuarios;
        private readonly APIService _APIService;


        public LoginPage(APIService apiservice)
        {
            InitializeComponent();
            _APIService = apiservice;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            /*string username = Preferences.Get("username", "0");
            if (!username.Equals("0"))
            {
                Navigation.PushAsync(new ProductoPage(_APIService));
            }*/
        }

        private async void OnClickLogin(object sender, EventArgs e)
        {
            _usuarios = new User
            {
                UserMail = Username.Text,
                UserPassword = Password.Text
            };
            bool isValidUser = await _APIService.VerificarUsuario(_usuarios);
            if (isValidUser)
            {
                // Usuario v�lido, puedes realizar la navegaci�n a la siguiente p�gina
                await Navigation.PushAsync(new ProductoPage(_APIService));
            }
            else
            {
                // Muestra una alerta u otro mensaje indicando que el inicio de sesi�n fall�
                await DisplayAlert("Error", "Inicio de sesi�n fallido/Credenciales incorrectas", "OK");
            }


        }

    }
}