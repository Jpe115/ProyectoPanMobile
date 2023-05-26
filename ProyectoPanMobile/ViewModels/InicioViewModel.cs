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
    
    public partial class InicioViewModel: ObservableObject
    {
        //[ObservableProperty]
        //public PanesConFoto pancito;

        public ObservableCollection<Panes> panesList { get; set; } 
        
        public InicioViewModel()
        {
            panesList = new ObservableCollection<Panes>();
           
        }

        [RelayCommand]
        private Task Button()
        {
            Preferences.Set("SesionIniciada", false);
            return Task.FromResult(0);
        }

        [RelayCommand]
        private async Task Cart()
        {
            await Shell.Current.GoToAsync(nameof(Carrito), true);
        }

        PanRepository panRepository = new PanRepository();
        string[] fotos = { "pastel3leches.jpg", "pastelfrutosrojos.png", "pasteldechocolate.png",
        "pastelvainillanuez.png", "paydequeso.jpg", "paydemanzana.jpg", "paydefresa.jpg", "paydeoreo.jpg"};
        
        [RelayCommand]
        public async Task CargarPanes()
        {
            if (Preferences.Get("C",false))
            {
                panesList.Clear();
                var listita = await panRepository.PanesLista();
                foreach (var pan in listita)
                {
                    panesList.Add(pan);
                }
            }
            else
            {
                panesList.Clear();
                var listita = await panRepository.PanesLista();
                foreach (var pan in listita)
                {
                    panesList.Add(pan);
                }
                await panRepository.ActualizarImagenes(fotos);
                Preferences.Set("C", true);
            }
        }

        [RelayCommand]
        public async Task DetallesDelPan(Panes Panecito)
        {
            await Shell.Current.GoToAsync(nameof(DetallesPage),new Dictionary<string, object>
            {
                ["Panecito"] = Panecito
            });
        }
    }
}
