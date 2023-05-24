using ProyectoPanMobile.Models;
using ProyectoPanMobile.ViewModels;

namespace ProyectoPanMobile.Views;

public partial class Carrito : ContentPage
{
    public PanesConFoto Panes { get; set; }

    public Carrito(List<PanesConFoto> panesLista)
	{
		InitializeComponent();
		this.BindingContext = new CarritoViewModel(panesLista);
    }
}