using static System.Net.Mime.MediaTypeNames;
using System.Threading.Tasks;
using System.Threading;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using ProductoApp.Models;
using System.Collections.ObjectModel;
using ProductoApp.Services;

namespace ProductoApp;

public partial class ProductoPage : ContentPage
{
    ObservableCollection<Plato> products;
    private readonly APIService _APIService;
	public ProductoPage(APIService apiservice)
	{
		InitializeComponent();
        _APIService = apiservice;
       
    }


    protected async override void OnAppearing()
    {
        base.OnAppearing();
        string username = Preferences.Get("username", "0");
        //Username.Text = username;
        List<Plato> ListaProducts = await _APIService.obtenerPlato();
        products = new ObservableCollection<Plato>(ListaProducts);
        listaProductos.ItemsSource = products;
    }
  
    private async void OnClickShowDetails(object sender, SelectedItemChangedEventArgs e)
    {
        var toast = CommunityToolkit.Maui.Alerts.Toast.Make("Click en ver producto", ToastDuration.Short, 14);

        await toast.Show();
        Plato producto = e.SelectedItem as Plato;
        await Navigation.PushAsync(new DetalleProductoPage(_APIService)
        {
            BindingContext = producto,
        });
    }



}