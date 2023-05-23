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
        //private Panes panes;

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
            await Shell.Current.GoToAsync(nameof(Carrito));
        }
        PanRepository panRepository = new PanRepository();

        [RelayCommand]
        public async Task CargarPanes()
        {
            panesList.Clear();
            var listita = await panRepository.PanesLista();
            foreach (var pan in listita)
            {
                panesList.Add(pan);
            }
        }
        
}
}
