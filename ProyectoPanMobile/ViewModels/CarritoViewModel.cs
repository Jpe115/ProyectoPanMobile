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
    [QueryProperty(name:"listacompras","listacompras")]
    public partial class CarritoViewModel : ObservableObject
    {
        public ObservableCollection<PanesConFoto> panesconfotoList { get; set; }
        [ObservableProperty]
        public List<PanesConFoto> panesLista;

        public CarritoViewModel()
        {

        }

        

        public async Task CargarPanes()
        {
            await Task.Run(() =>
            {
                panesconfotoList.Clear();
                foreach (var panecitos in PanesLista)
                {
                    panesconfotoList.Add(panecitos);
                }
            });
            
        }
    }
}
