using ProyectoPanMobile.Models;
using ProyectoPanMobile.ViewModels;

namespace ProyectoPanMobile.Views;

public partial class Carrito : ContentPage
{

    public Carrito(CarritoViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
    }
}