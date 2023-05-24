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
        //[ObservableObject]
        public PanesConFoto panecito;

        public DetallesPageViewModel(PanesConFoto panecito) {
            panecito = new PanesConFoto();
        }
    }
}
