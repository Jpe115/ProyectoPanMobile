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

        [ObservableProperty]
        int steppervalue = 1;

        PanRepository panRepository = new PanRepository();
        [RelayCommand]
        public async Task Mandar()
        {
            await panRepository.AgregarAlCarrito(Panecito, Steppervalue);
            await Shell.Current.GoToAsync("..", true);
        }

        [RelayCommand]
        public async Task Plus()
        {
            if (Steppervalue < 10)
            {
                await Task.Run(() =>
                {
                    Steppervalue += 1;
                    Panecito.Cantidad += 1;
                });
            }
        }

        [RelayCommand]
        public async Task Minus()
        {
            if (Steppervalue > 1)
            {
                await Task.Run(() =>
                {
                    Steppervalue -= 1;
                    Panecito.Cantidad -= 1;
                });
            }
        }
    }
}
