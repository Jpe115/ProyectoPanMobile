using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using ProyectoPanMobile.Data;
using ProyectoPanMobile.ViewModels;

namespace ProyectoPanMobile.Views;

public partial class Cuenta : ContentPage
{
	CuentaViewModel viewModel;
	public Cuenta()
	{
		InitializeComponent();
		BindingContext = viewModel = new CuentaViewModel();
	}
    PanRepository panRepository = new PanRepository();
    public async Task guardar()
	{
		if(Usuario.Text != string.Empty)
		{
			await DisplayAlert("Se han guardado los cambios", "Bien","Ok");
		}
	}

    protected override async void OnAppearing()
    {
		await viewModel.ObtenerUsuario();
        base.OnAppearing();
        SwContra.IsToggled = false;
        SwUsuario.IsToggled = false;
    }

    private void SwContra_Toggled(object sender, ToggledEventArgs e)
    {
		if (Contra.IsEnabled == true && Confirmar.IsEnabled == true){
			Contra.IsEnabled = false;
			Confirmar.IsEnabled = false;
		}
		else
		{
			Contra.IsEnabled = true;
			Confirmar.IsEnabled = true;
		}
    }

    private void SwUsuario_Toggled(object sender, ToggledEventArgs e)
    {
		if (Correo.IsEnabled == true)
		{
			Correo.IsEnabled = false;
		}
		else
		{
			Correo.IsEnabled = true;
		}
    }

    private async void BtnGuardar_Clicked(object sender, EventArgs e)
    {
		if (Contra.IsEnabled == true)
		{
			if(Contra.Text != Confirmar.Text)
			{
				await DisplayAlert("Error 0.0", "Contraseñas no coinciden. Intente de nuevo", "Ok");
			}
			else
			{
                if (Correo.IsEnabled == true)
                {
                    bool resp = await DisplayAlert("Advertencia", "¿Está seguro que desea realizar los cambios?", "Sí", "No");
                    if(resp == true)
                    {
                        viewModel.UsuarioActivo.NombreUsuario = Usuario.Text;
                        viewModel.UsuarioActivo.Email = Correo.Text;
                        viewModel.UsuarioActivo.Contraseña = Contra.Text;
                        viewModel.UsuarioActivo.Foto = "";//Por implementar
                        viewModel.UsuarioActivo.Telefono = Convert.ToInt32(Telefono.Text);
                        viewModel.UsuarioActivo.Direccion = Direccion.Text;
                        await panRepository.ModificarUsuario(viewModel.UsuarioActivo);
                        await Toast.Make("Cambios a su cuenta realizados", ToastDuration.Short).Show();
                    }
                }
                else
                {
                    bool resp = await DisplayAlert("Advertencia", "¿Está seguro que desea realizar los cambios?", "Sí", "No");
                    if (resp == true)
                    {
                        viewModel.UsuarioActivo.NombreUsuario = Usuario.Text;
                        //viewModel.UsuarioActivo.Email = Correo.Text;
                        viewModel.UsuarioActivo.Contraseña = Contra.Text;
                        viewModel.UsuarioActivo.Foto = "";//Por implementar
                        viewModel.UsuarioActivo.Telefono = Convert.ToInt32(Telefono.Text);
                        viewModel.UsuarioActivo.Direccion = Direccion.Text;
                        await panRepository.ModificarUsuario(viewModel.UsuarioActivo);
                        await Toast.Make("Cambios a su cuenta realizados", ToastDuration.Short).Show();
                    }
                }
            }
		}
        else
        {
            if (Correo.IsEnabled == true)
            {
                bool resp = await DisplayAlert("Advertencia", "¿Está seguro que desea realizar los cambios?", "Sí", "No");
                if (resp == true)
                {
                    viewModel.UsuarioActivo.NombreUsuario = Usuario.Text;
                    viewModel.UsuarioActivo.Email = Correo.Text;
                    //viewModel.UsuarioActivo.Contraseña = Contra.Text;
                    viewModel.UsuarioActivo.Foto = "";//Por implementar
                    viewModel.UsuarioActivo.Telefono = Convert.ToInt32(Telefono.Text);
                    viewModel.UsuarioActivo.Direccion = Direccion.Text;
                    await panRepository.ModificarUsuario(viewModel.UsuarioActivo);
                    await Toast.Make("Cambios a su cuenta realizados", ToastDuration.Short).Show();
                }
            }
			else
			{
                bool resp = await DisplayAlert("Advertencia", "¿Está seguro que desea realizar los cambios?", "Sí", "No");
                if (resp == true)
                {
                    viewModel.UsuarioActivo.NombreUsuario = Usuario.Text;
                    //viewModel.UsuarioActivo.Email = Correo.Text;
                    //viewModel.UsuarioActivo.Contraseña = Contra.Text;
                    viewModel.UsuarioActivo.Foto = "";//Por implementar
                    viewModel.UsuarioActivo.Telefono = Convert.ToInt32(Telefono.Text);
                    viewModel.UsuarioActivo.Direccion = Direccion.Text;
                    await panRepository.ModificarUsuario(viewModel.UsuarioActivo);
                    await Toast.Make("Cambios a su cuenta realizados",ToastDuration.Short).Show();
                }
            }
        }

    }
}