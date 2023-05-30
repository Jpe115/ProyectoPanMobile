using ProyectoPanMobile.Models;
using ProyectoPanMobile.Views;

namespace ProyectoPanMobile;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(Login1), typeof(Login1));
        Routing.RegisterRoute(nameof(Login2), typeof(Login2)); 
        Routing.RegisterRoute(nameof(Inicio), typeof(Inicio));
        Routing.RegisterRoute(nameof(Cuenta), typeof(Cuenta));
        Routing.RegisterRoute(nameof(Carrito), typeof(Carrito));
        Routing.RegisterRoute(nameof(DetallesPage), typeof(DetallesPage));
        Routing.RegisterRoute(nameof(AppShell), typeof(AppShell));
    }

    private async void CerrarSesion_Clicked(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("¿Desea cerrar sesión?", null , "Cerrar", "Mantener");
        if (answer) {
            Preferences.Set("SesionIniciada", false);
            await Shell.Current.GoToAsync("Login1");
        }
    }
    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        if (Preferences.Get("SesionIniciada", true))
        {
            await Shell.Current.GoToAsync("//Inicio");
        }
        else
        {
            await Shell.Current.GoToAsync("//Login1");
        }
    }
}
