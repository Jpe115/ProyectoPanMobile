using ProyectoPanMobile.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using ProyectoPanMobile.Models;
using ProyectoPanMobile.Data;
using System.Collections.ObjectModel;

namespace ProyectoPanMobile.ViewModels
{
    [QueryProperty(name: "listacompras", queryId:"listacompras")]
    public partial class InicioViewModel: ObservableObject
    {
        [ObservableProperty]
        public List<PanesConFoto> listacompras;

        //[ObservableProperty]
        //public PanesConFoto pancito;

        public ObservableCollection<PanesConFoto> panesconfotoList { get; set; } 
        
        public InicioViewModel()
        {
            panesconfotoList = new ObservableCollection<PanesConFoto>();
           
        }

        [RelayCommand]
        private Task Button()
        {
            Preferences.Set("SesionIniciada", false);
            return Task.FromResult(0);
        }

        [RelayCommand]
        private async Task Cart(List<PanesConFoto> listacompras)
        {
            await Shell.Current.GoToAsync(nameof(Carrito),true, new Dictionary<string, object>
            {
                ["listacompras"] = listacompras
            });
        }

        PanRepository panRepository = new PanRepository();
        string[] fotos = { "pastel3leches.jpg", "pastelfrutosrojos.png", "pasteldechocolate.png",
        "pastelvainillanuez.png", "paydequeso.jpg", "paydemanzana.jpg", "paydefresa.jpg", "paydeoreo.jpg"};
        
        [RelayCommand]
        public async Task CargarPanes()
        {
            panesconfotoList.Clear();
            var listita = await panRepository.PanesLista();
            for (int i=0; i<listita.Count;i++)
            {
                PanesConFoto panecitos = new PanesConFoto() { pan = listita[i], imagensource = fotos[i] };
                panesconfotoList.Add(panecitos);
            }
        }

        [RelayCommand]
        public async Task DetallesDelPan(PanesConFoto Panecito)
        {
            await Shell.Current.GoToAsync(nameof(DetallesPage),new Dictionary<string, object>
            {
                ["Panecito"] = Panecito
            });
        }
    }
}
