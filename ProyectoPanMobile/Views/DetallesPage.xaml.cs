using ProyectoPanMobile.Models;
using ProyectoPanMobile.ViewModels;

namespace ProyectoPanMobile.Views;

public partial class DetallesPage : ContentPage
{
	public PanesConFoto Panes { get; set; }

	public DetallesPage(PanesConFoto pancito)
	{
		InitializeComponent();
		this.BindingContext = new DetallesPageViewModel();
        ((DetallesPageViewModel)BindingContext).Panecito = pancito;
    }
}