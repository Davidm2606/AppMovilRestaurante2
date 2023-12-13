using CommunityToolkit.Maui.Core;
using ProductoApp.Models;
using ProductoApp.Services;
using System.ComponentModel;
using System.Windows.Input;

namespace ProductoApp;

public partial class DetalleProductoPage : ContentPage
{
   private Plato _producto;

    private APIService _APIService;
    private List<Plato> listaPlatos = new List<Plato>();

    public DetalleProductoPage(APIService apiservice)
	{
		InitializeComponent();
        _APIService = apiservice;
       
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _producto = BindingContext as Plato;
        Nombre.Text = _producto.Nombre;
        Cantidad.Text = _producto.Cantidad.ToString();
        Descripcion.Text = _producto.Ingredientes;

    }

    private async void AgregarAlCarrito_Clicked(object sender, EventArgs e)
    {
        // Crear un objeto para pasar datos a CarritoPage
        var datosCarrito = new Plato
        {
            Nombre = _producto.Nombre,
            Cantidad = _producto.Cantidad,
            Precio = _producto.Precio // Asegúrate de tener un campo "precio" en tu modelo Plato
        };

        // Crear una instancia de CarritoPage y pasar datos
        var carritoPage = new CarritoPage(datosCarrito);

        // Navegar a la página CarritoPage
        await Navigation.PushAsync(carritoPage);
    }

}







