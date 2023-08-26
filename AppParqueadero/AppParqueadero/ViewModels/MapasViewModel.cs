using AppParqueadero.Data.Api;
using AppParqueadero.Data.Models;
using AppParqueadero.Data.Models.Dto;
using AppParqueadero.Services;
using AppParqueadero.Views;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace AppParqueadero.ViewModels
{
    class MapasViewModel: BaseViewModel
    {
        public readonly IClientService _clientService;
        public readonly IGoogleMapsService _googleMapsService;

        public MapasViewModel(IClientService clientService, IGoogleMapsService googleService) 
        {
            _googleMapsService = googleService;
            AppearingCommand = new AsyncCommand(async () => await OnAppearingAsync());
            _clientService = clientService;
            DetalleParqueadero = new AsyncCommand(OnClientTapped);
        }

        public ICommand DetalleParqueadero { get; }
        public ObservableRangeCollection<Client> Clients { get; set; } = new ObservableRangeCollection<Client>();
        public Client Client { get; set; } = new Client();

        public ICommand AppearingCommand { get; set; }

        private async Task OnAppearingAsync()
        {
            await LoadData();
        }


        private async Task LoadData()
        {
            try
            {
                IsBusy = true;
                var clients = await _clientService.GetClientsAsync();
                if (clients != null)
                {
                    Clients.ReplaceRange(clients);
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }
            finally
            {
                IsBusy = false;
            }
        }

        private Task OnClientTapped()
        {
            if (Client == null)
            {
                return Task.CompletedTask;
            }


            return Shell.Current.GoToAsync($"{nameof(ClientDetallePage)}?{nameof(ClientDetalleViewModel.ClientId)}={Client.id}");
        }

    }
}
