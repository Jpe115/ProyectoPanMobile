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
	}
}
