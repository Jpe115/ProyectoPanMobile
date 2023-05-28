﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProyectoPanMobile.Data;
using ProyectoPanMobile.Models;
using ProyectoPanMobile.Views;
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
        public ObservableCollection<PanesCarrito> panesList { get; set; }

        [ObservableProperty]
        int steppervalue = 1;

        public CarritoViewModel()
        {
            panesList = new ObservableCollection<PanesCarrito>();
        }

        string[] fotos = { "pastel3leches.jpg", "pastelfrutosrojos.png", "pasteldechocolate.png",
        "pastelvainillanuez.png", "paydequeso.jpg", "paydemanzana.jpg", "paydefresa.jpg", "paydeoreo.jpg"};

        PanRepository panRepository = new PanRepository();
        public async Task CargarCarrito(string[] fotos)
        {
            panesList.Clear();
            var listita = await panRepository.Carrito();
            foreach (var panecitos in listita)
            {
                panesList.Add(panecitos);
            }
            await panRepository.ImgsACarrito(fotos);
        }
        public async Task CargarCarrito()
        {
            panesList.Clear();
            var listita = await panRepository.Carrito();
            foreach (var panecitos in listita)
            {
                panesList.Add(panecitos);
            }
        }

        [RelayCommand]
        public async Task DetallesDelPan(PanesCarrito Panecito)
        {
            await Shell.Current.GoToAsync(nameof(DetallesPage), new Dictionary<string, object>
            {
                ["Panecito"] = Panecito
            });
        }

        [RelayCommand]
        public async Task Plus()
        {
            if (Steppervalue < 10)
            {
                await Task.Run(() =>
                {
                    Steppervalue += 1;
                });
            }
        }

        [RelayCommand]
        public async Task Menos()
        {
            if (Steppervalue > 1)
            {
                await Task.Run(() =>
                {
                    Steppervalue -= 1;
                });
            }
        }
    }
}
