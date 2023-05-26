namespace ProyectoPanMobile.Views;

public partial class Cuenta : ContentPage
{
	public Cuenta()
	{
		InitializeComponent();
	}
	public async Task guardar()
	{
		if(Usuario.Text != string.Empty)
		{
			await DisplayAlert("Se han guardado los cambios", "Bien","Ok");
		}
	}
}