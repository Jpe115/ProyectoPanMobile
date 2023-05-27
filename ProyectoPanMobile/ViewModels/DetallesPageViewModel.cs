using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProyectoPanMobile.Data;
using ProyectoPanMobile.Models;
using ProyectoPanMobile.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPanMobile.ViewModels
{
    [QueryProperty("Panecito", "Panecito")]
    public partial class DetallesPageViewModel: ObservableObject
    {
        [ObservableProperty]
        PanesCarrito panecito;

        public DetallesPageViewModel() {
            
        }

        PanRepository panRepository = new PanRepository();
        [RelayCommand]
        public async Task Mandar()
        {
            await panRepository.AgregarAlCarrito(Panecito, Steppervalue);
            await Shell.Current.GoToAsync("..", true);
        }
    }
}
