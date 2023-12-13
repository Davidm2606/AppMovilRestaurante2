using Acr.UserDialogs;
using CommunityToolkit.Maui.Alerts;
using ProductoApp.Models;
using ProductoApp.Services;

namespace ProductoApp;

public partial class CarritoPage : ContentPage
{

    private readonly APIService _APIService = new APIService(); 
    private Plato _datosCarrito;

    public CarritoPage(Plato plato)
    {
        InitializeComponent();

        _datosCarrito = plato;


        BindingContext = _datosCarrito;

        NombreLabel.Text = _datosCarrito.Nombre;
        
        PrecioLabel.Text = string.Format("Precio: {0:C}", _datosCarrito.Precio);
    }
    private async void OnClickComprar(object sender, EventArgs e)
    {
        try
        {
            await DisplayAlert("Información", "El restaurante ya está preparando su pedido. El pago se realiza directamente en el local.", "OK");

            await Navigation.PushAsync(new ProductoPage(_APIService));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Excepción: {ex.Message}");
        }
    }

}








