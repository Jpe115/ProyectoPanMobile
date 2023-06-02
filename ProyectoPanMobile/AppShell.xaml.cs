//using Android.Net.Wifi.Aware;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using ProyectoPanMobile.Models;
using ProyectoPanMobile.ViewModels;
using ProyectoPanMobile.Views;

namespace ProyectoPanMobile;

public partial class AppShell : Shell
{
    AppShellViewModel viewModel;
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

        BindingContext = viewModel = new AppShellViewModel();
    }

    private async void CerrarSesion_Clicked(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("¿Desea cerrar sesión?", null , "Cerrar", "Mantener");
        if (answer) {
            SecureStorage.RemoveAll();
            await Toast.Make("Sesión cerrada", ToastDuration.Short).Show();
            await Shell.Current.GoToAsync("Login1");
        }
    }

    protected override async void OnNavigated(ShellNavigatedEventArgs args)
    {
        base.OnNavigated(args);
        await viewModel.ObtenerUsuario();
    }
}
