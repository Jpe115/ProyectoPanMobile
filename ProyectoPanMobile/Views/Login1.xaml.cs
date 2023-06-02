using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Core.Platform;
using Microsoft.Maui.Controls.Xaml;
using ProyectoPanMobile.Data;
using ProyectoPanMobile.Models;

namespace ProyectoPanMobile.Views;

public partial class Login1 : ContentPage
{
	public Login1()
	{
		InitializeComponent();
        
	}
    
    

    private async void BtnIniciar_Clicked(object sender, EventArgs e)
    {
        try
        {
            string usuario = Correo.Text;
            string password = Contra.Text;

            PanRepository panRepository = new PanRepository();
            int existe = await panRepository.ExisteUsuario(usuario, password);
            if (usuario == null || password == null)
            {
                await DisplayAlert("Error O.o", "Alguno de los campos está vacío", "Ok");
            }
            else if (password.Length < 4)
            {
                await DisplayAlert("Error O.o", "La contraseña debe contener al menos 4 caracteres", "Ok");
            }
            else if(existe !=0)
            {
                string id = existe.ToString();
                await SecureStorage.SetAsync("isAuth", "true");
                await SecureStorage.SetAsync("cuenta", id);
                await Toast.Make("Sesión iniciada", ToastDuration.Short).Show();
                await Shell.Current.GoToAsync("//Inicio");
            }
            else
            {
                await DisplayAlert("Error 0.o","Contraseña o nombre de usuario incorrectos. ¿Ya ha creado su cuenta?", "Ok");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error D:", ex.Message, "Ok");
        }
    }

    private async void BtnCrear_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(Login2));
    }
    protected override bool OnBackButtonPressed()
    {
        Application.Current.CloseWindow(Window);
        return true;
    }
}