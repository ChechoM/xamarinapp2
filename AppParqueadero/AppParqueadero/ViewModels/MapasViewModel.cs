using AppParqueadero.Data.Models;
using AppParqueadero.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;

namespace AppParqueadero.ViewModels
{
    class MapasViewModel: BaseViewModel
    {
        private readonly IClientService _clientService;
        private ObservableRangeCollection<Client> _clients;

        public MapasViewModel(IClientService clientService) 
        {
            AppearingCommand = new AsyncCommand(async () => await OnAppearingAsync());
            _clientService = clientService;
        }

        public ObservableRangeCollection<Client> Client { get; set; } = new ObservableRangeCollection<Client>();

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
                    Client.ReplaceRange(clients);
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
    }
}
