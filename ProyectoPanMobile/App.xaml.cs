using ProyectoPanMobile.Models;
using ProyectoPanMobile.Views;

namespace ProyectoPanMobile;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        MainPage = new AppShell();
        Shell.Current.GoToAsync(nameof(Login1));
	}
    /*public void pagina()
    {
        var isAuthenticated = Preferences.Get("SesionIniciada",false);
        if (isAuthenticated)
        {
            MainPage = new AppShell();
        }
        else
        {
            MainPage = new Login1();
        }
    }*/
}
