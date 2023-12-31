﻿using AppParqueadero.Data.Models;
using AppParqueadero.Data.Models.Dto;
using AppParqueadero.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace AppParqueadero.ViewModels
{
    [QueryProperty(nameof(ClientId), nameof(ClientId))]
    public class ClientDetalleViewModel : BaseViewModel
    {        

        private readonly IClientDetalleService _clientDetalleService;


        private Client _client;
        private List<Calificaciones> _calificaciones;
        public Client Client { get => _client; set => SetProperty(ref _client, value); }
        public List<Calificaciones> Calificaciones { get => _calificaciones; set => SetProperty(ref _calificaciones, value); }

        private long _clientId;
        public long ClientId { get => _clientId; set => SetProperty(ref _clientId, value); }

        private long _id;
        public long Id
        {

            get => _id;
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged();
                }
            }
        }

        public ClientDetalleViewModel(IClientDetalleService clientDetalleService)
        {

            AppearingCommand = new AsyncCommand(async () => await OnAppearingAsync());
            _clientDetalleService = clientDetalleService;
            
        }

        public ICommand AppearingCommand { get; set; }

        private async Task OnAppearingAsync()
        {

            LoadDetalle();
            LoadCalificaciones();
        }

        public async Task LoadDetalle()
        {
            try
            {
                IsBusy = true;

                Client = await _clientDetalleService.GetClientAsync(ClientId);
            }
            catch (Exception ex)
            {
                var mensaje = ex.Message;
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task LoadCalificaciones()
        {
            try
            {
                IsBusy = true;

                Calificaciones = await _clientDetalleService.GetCalificacionesPorCLiente(ClientId);
            }
            catch (Exception ex)
            {
                var mensaje = ex.Message;
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
