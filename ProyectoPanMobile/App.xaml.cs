using ProyectoPanMobile.Models;
using ProyectoPanMobile.Views;

namespace ProyectoPanMobile;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        pagina();
	}
    public void pagina()
    {
        var isAuthenticated = Preferences.Get("SesionIniciada",false);
        if (isAuthenticated)
        {
            Application.Current.MainPage = new AppShell();
        }
        else
        {
            Application.Current.MainPage = new Login1();
        }
    }
}
