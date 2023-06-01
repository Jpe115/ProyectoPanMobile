using CommunityToolkit.Mvvm.ComponentModel;
using ProyectoPanMobile.Data;
using ProyectoPanMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPanMobile.ViewModels
{
    public partial class CuentaViewModel:ObservableObject
    {
        public CuentaViewModel() {
            usuarioActivo = new Usuarios();
        }

        [ObservableProperty]
        Usuarios usuarioActivo;

        PanRepository panRepository = new PanRepository();
        public async Task ObtenerUsuario()
        {
            var usuario = await SecureStorage.GetAsync("cuenta");
            UsuarioActivo = await panRepository.CualUsuario(usuario);
        }
    }
}
