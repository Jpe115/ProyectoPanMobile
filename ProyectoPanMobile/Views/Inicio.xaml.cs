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
        base.OnAppearing();
        await viewModel.CargarPanes();
    }

}