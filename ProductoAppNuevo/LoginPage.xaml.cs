using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using ProductoApp.Models;
using ProductoApp.Services;

namespace ProductoApp;

public partial class LoginPage : ContentPage
{
    private readonly APIService _APIService;
    public LoginPage(APIService apiservice)
	{
		InitializeComponent();
        _APIService = apiservice;
       
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        string username = Preferences.Get("username", "0");
        if(!username.Equals("0"))
        {
            await Navigation.PushAsync(new ProductoPage(_APIService));
        }
    }

    private async void OnClickLogin(object sender, EventArgs e)
    {
        string username = Username.Text;
        string password = Password.Text;
        Usuario usuario = new Usuario
        {
            IdUsuario = 0,
            Username = username,
            Password = password
        };
        
        Usuario usuario2 = _APIService.PostUsuario(usuario);
        if (usuario2!=null)
        {
            Preferences.Set("username", username);
            Preferences.Set("idusuario", usuario2.IdUsuario);
            await Navigation.PushAsync(new ProductoPage(_APIService));
        }
        else
        {
            var toast = Toast.Make("Nombre de usuario o password incorrecto", ToastDuration.Short, 14);
            await toast.Show();
        }

          

    }
}