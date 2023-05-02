

using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Core.Platform;
using Microsoft.Maui.Controls.Xaml;
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
            string email = Correo.Text;
            string password = Contra.Text;
            if (email == null || password == null)
            {
                await DisplayAlert("Error O.o", "Alguno de los campos est� vac�o", "Ok");
            }
            else if (password.Length < 4)
            {
                await DisplayAlert("Error O.o", "La contrase�a debe contener al menos 4 caracteres", "Ok");
            }
            else
            {
                Preferences.Set("SesionIniciada", true);
                await Navigation.PushModalAsync(new Inicio());
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error D:", ex.Message, "Ok");
        }
    }

    private async void BtnCrear_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Login2());
    }
    protected override bool OnBackButtonPressed()
    {
        Application.Current.CloseWindow(Window);
        return true;
    }
}