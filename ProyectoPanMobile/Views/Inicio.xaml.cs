using Microsoft.Maui.Controls;

namespace ProyectoPanMobile.Views;

public partial class Inicio : ContentPage
{
	public Inicio()
	{
		InitializeComponent();
	}
    protected override bool OnBackButtonPressed()
    {
        Application.Current.CloseWindow(Window);
        return true;
    }
}