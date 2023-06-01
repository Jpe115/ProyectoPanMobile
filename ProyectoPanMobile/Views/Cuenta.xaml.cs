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

    private void SwContra_Toggled(object sender, ToggledEventArgs e)
    {
		if (Contra.IsEnabled == true && Confirmar.IsEnabled == true){
			Contra.IsEnabled = false;
			Confirmar.IsEnabled = false;
		}
		else
		{
			Contra.IsEnabled = true;
			Confirmar.IsEnabled = true;
		}
    }

    private void SwUsuario_Toggled(object sender, ToggledEventArgs e)
    {
		if (Correo.IsEnabled == true)
		{
			Correo.IsEnabled = false;
		}
		else
		{
			Correo.IsEnabled = true;
		}
    }
}