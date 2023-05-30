namespace ProyectoPanMobile.Views;

public partial class Login2 : ContentPage
{
	public Login2()
	{
		InitializeComponent();
	}

    private async void BtnCrear_Clicked(object sender, EventArgs e)
    {
		try
		{
			string email = Correo.Text;
			string password = Contra.Text;
			string confpassword = Confirmar.Text;
			if (email == null || password == null || confpassword == null)
			{
                await DisplayAlert("Error O.o", "Alguno de los campos est� vac�o", "Ok");
            }
            else if (password.Length < 4)
            {
                await DisplayAlert("Error O.o", "La contrase�a debe contener al menos 4 caracteres", "Ok");
            }
            else if(confpassword != password)
			{
                await DisplayAlert("Error O.o", "Contrase�as no coinciden. Intente nuevamente", "Ok");
            }else
			{
                Preferences.Set("SesionIniciada", true);
				await DisplayAlert("Bien :D", "Cuenta creada exitosamente", "Ok");
                await Shell.Current.GoToAsync("//Inicio");
            }
		}catch (Exception ex)
		{
			await DisplayAlert("Error D:", ex.Message,"Ok");
		}
    }
}