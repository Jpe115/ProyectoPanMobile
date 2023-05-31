using ProyectoPanMobile.ViewModels;

namespace ProyectoPanMobile.Views;

public partial class Cuenta : ContentPage
{
	CuentaViewModel viewModel;
	public Cuenta()
	{
		InitializeComponent();
		BindingContext = viewModel = new CuentaViewModel();
	}
	public async Task guardar()
	{
		if(Usuario.Text != string.Empty)
		{
			await DisplayAlert("Se han guardado los cambios", "Bien","Ok");
		}
	}

    protected override async void OnAppearing()
    {
		await viewModel.ObtenerUsuario();
        base.OnAppearing();
    }
}