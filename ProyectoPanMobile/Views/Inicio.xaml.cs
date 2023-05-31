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
        var isAuth = await auth();
        if (isAuth == "true")
        {
            //await Shell.Current.GoToAsync("//Inicio");
        }
        else
        {
            await Shell.Current.GoToAsync("Login1");
        }
        await viewModel.CargarPanes();
        base.OnAppearing();
    }
    public async Task<string> auth()
    {
        var isAuth = await SecureStorage.GetAsync("isAuth");
        return isAuth;
    }

}