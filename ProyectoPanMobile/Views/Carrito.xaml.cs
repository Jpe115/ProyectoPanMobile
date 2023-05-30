using ProyectoPanMobile.Data;
using ProyectoPanMobile.Models;
using ProyectoPanMobile.ViewModels;

namespace ProyectoPanMobile.Views;

public partial class Carrito : ContentPage
{
    CarritoViewModel vm;
    public Carrito()
	{
		InitializeComponent();
		BindingContext = vm = new CarritoViewModel();
    }
    PanRepository panRepository = new PanRepository();
    private async void Pagar(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("¿Desea continuar con el pago?", null, "Pagar ahora", "Todavía no");
        if (answer)
        {
            await panRepository.ReiniciarCarrito();
            await vm.CargarCarrito();
        }
    }
    protected override async void OnAppearing()
    {
        await vm.CargarCarrito();
        base.OnAppearing();
    }

    string[] fotos = { "pastel3leches.jpg", "pastelfrutosrojos.png", "pasteldechocolate.png",
        "pastelvainillanuez.png", "paydequeso.jpg", "paydemanzana.jpg", "paydefresa.jpg", "paydeoreo.jpg"};
}