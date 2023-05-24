using ProyectoPanMobile.ViewModels;

namespace ProyectoPanMobile.Views;

public partial class DetallesPage : ContentPage
{
	DetallesPageViewModel viewModel;
	public DetallesPage()
	{
		InitializeComponent();
		//BindingContext = viewModel = new DetallesPageViewModel(panecito);
	}
}