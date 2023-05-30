using Microsoft.Maui.Controls;
using ProyectoPanMobile.Data;
using ProyectoPanMobile.Models;
using ProyectoPanMobile.ViewModels;
using System.Collections.ObjectModel;

namespace ProyectoPanMobile.Views;

public partial class Inicio : ContentPage
{
    InicioViewModel viewModel;
    
	public Inicio()
	{
		InitializeComponent();
        BindingContext = viewModel = new InicioViewModel();
    }
    protected override bool OnBackButtonPressed()
    {
        Application.Current.CloseWindow(Window);
        return true;
    }

    protected async override void OnAppearing()
    {
        if (Preferences.Get("SesionIniciada", true))
        {
            //await Shell.Current.GoToAsync($"//{nameof(AppShell)}");
        }
        else
        {
            await Shell.Current.GoToAsync("//Login1");
        }
        await viewModel.CargarPanes();
        base.OnAppearing();
    }

}