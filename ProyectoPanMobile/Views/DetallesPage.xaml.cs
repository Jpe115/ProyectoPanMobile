using ProyectoPanMobile.Models;
using ProyectoPanMobile.ViewModels;

namespace ProyectoPanMobile.Views;

public partial class DetallesPage : ContentPage
{
	

	public DetallesPage(DetallesPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
        
    }
}