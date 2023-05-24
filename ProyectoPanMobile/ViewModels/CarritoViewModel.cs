using CommunityToolkit.Mvvm.ComponentModel;
using ProyectoPanMobile.Data;
using ProyectoPanMobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPanMobile.ViewModels
{
    public partial class CarritoViewModel : ObservableObject
    {
        public ObservableCollection<PanesConFoto> panesconfotoList { get; set; }
        public List<PanesConFoto> panesLista { get; set; }

        public CarritoViewModel(List<PanesConFoto> panesLizta)
        {
            panesconfotoList = new ObservableCollection<PanesConFoto>();
            panesLista = panesLizta;
        }

        public async Task CargarPanes()
        {
            await Task.Run(() =>
            {
                panesconfotoList.Clear();
                foreach (var panecitos in panesLista)
                {
                    panesconfotoList.Add(panecitos);
                }
            });
            
        }
    }
}
