using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using ProyectoPanMobile.Data;

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
			string usuario = Correo.Text;
			string password = Contra.Text;
			string confpassword = Confirmar.Text;

            PanRepository panRepository = new PanRepository();
            bool repetido = await panRepository.isUsuarioRepetido(usuario);

            if (usuario == null || password == null || confpassword == null)
			{
                await DisplayAlert("Error O.o", "Alguno de los campos está vacío", "Ok");
            }
            else if (password.Length < 4)
            {
                await DisplayAlert("Error O.o", "La contraseña debe contener al menos 4 caracteres", "Ok");
            }
            else if(confpassword != password)
			{
                await DisplayAlert("Error O.o", "Contraseñas no coinciden. Intente nuevamente", "Ok");
            }
            else if (repetido)
            {
                await DisplayAlert("Error O.o", "Usuario ya existe", "Ok");
            }
            else
			{
                await panRepository.RegistrarUsuario(usuario, password);
                await SecureStorage.SetAsync("isAuth", "true");
                int cual = await panRepository.ExisteUsuario(usuario,password);
                string id = cual.ToString();
                await SecureStorage.SetAsync("cuenta",id);
                await Toast.Make("Cuenta creada exitosamente", ToastDuration.Short).Show();
                await Shell.Current.GoToAsync("//Inicio");
            }
		}catch (Exception ex)
		{
			await DisplayAlert("Error D:", ex.Message,"Ok");
		}
    }
}