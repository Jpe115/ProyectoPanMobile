using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
        Panes panecito;

        public DetallesPageViewModel() {
            
        }

        [RelayCommand]
        public async Task Mandar()
        {
            await Shell.Current.GoToAsync("..", true);
        }
    }
}
