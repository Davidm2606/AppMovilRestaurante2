using Acr.UserDialogs;
using CommunityToolkit.Maui.Alerts;
using ProductoApp.Models;
using ProductoApp.Services;

namespace ProductoApp;

public partial class CarritoPage : ContentPage
{
    // Declaración y asignación de _APIService en algún lugar del código
    private readonly APIService _APIService = new APIService(); // Asegúrate de usar la clase real que implementa tu servicio
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
            await DisplayAlert("Información", "El restaurante ya está preparando su pedido. El pago se realiza directamente en el local.", "OK");

            // Navega a la página ProductoPage con el parámetro APIService
            await Navigation.PushAsync(new ProductoPage(_APIService));
        }
        catch (Exception ex)
        {
            // Captura y muestra cualquier excepción no manejada
            Console.WriteLine($"Excepción: {ex.Message}");
        }
    }

}








