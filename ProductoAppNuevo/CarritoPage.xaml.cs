using Acr.UserDialogs;
using CommunityToolkit.Maui.Alerts;
using ProductoApp.Models;
using ProductoApp.Services;

namespace ProductoApp;

public partial class CarritoPage : ContentPage
{
    // Declaraci�n y asignaci�n de _APIService en alg�n lugar del c�digo
    private readonly APIService _APIService = new APIService(); // Aseg�rate de usar la clase real que implementa tu servicio
    private Plato _datosCarrito;

    public CarritoPage(Plato plato)
    {
        InitializeComponent();

        _datosCarrito = plato;

        // Configurar el contexto de datos
        BindingContext = _datosCarrito;

        // Actualizar los Labels con los datos
        NombreLabel.Text = _datosCarrito.Nombre;
        
        PrecioLabel.Text = string.Format("Precio: {0:C}", _datosCarrito.Precio);
    }
    private async void OnClickComprar(object sender, EventArgs e)
    {
        try
        {
            // Muestra el mensaje
            await DisplayAlert("Informaci�n", "El restaurante ya est� preparando su pedido. El pago se realiza directamente en el local.", "OK");

            // Navega a la p�gina ProductoPage con el par�metro APIService
            await Navigation.PushAsync(new ProductoPage(_APIService));
        }
        catch (Exception ex)
        {
            // Captura y muestra cualquier excepci�n no manejada
            Console.WriteLine($"Excepci�n: {ex.Message}");
        }
    }

}








