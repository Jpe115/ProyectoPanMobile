using ProyectoPanMobile.Views;

namespace ProyectoPanMobile;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(Login2), typeof(Login2));
	}
}
