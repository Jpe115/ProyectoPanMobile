using CommunityToolkit.Mvvm.ComponentModel;
using ProyectoPanMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPanMobile.ViewModels
{
    public partial class DetallesPageViewModel: ObservableObject
    {
        [ObservableProperty]
        private PanesConFoto panecito;

        public DetallesPageViewModel() {
            panecito = new PanesConFoto();
        }
    }
}
