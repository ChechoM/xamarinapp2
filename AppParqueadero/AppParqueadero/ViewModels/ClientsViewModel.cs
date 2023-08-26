using AppParqueadero.Data.Models;
using AppParqueadero.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;

namespace AppParqueadero.ViewModels
{
    public class ClientsViewModel : BaseViewModel
    {
        private readonly IClientService _clientService;
        private readonly IAppUserSettingService _appUserSettingService;

        public ClientsViewModel(IClientService clientService, IAppUserSettingService appUserSettingService)
        {
            AppearingCommand = new AsyncCommand(async () => await OnAppearingAsync());
            Title = "Clients";
            _clientService = clientService;
            _appUserSettingService = appUserSettingService;
        }

        public ObservableRangeCollection<Client> Clients { get; set; } = new ObservableRangeCollection<Client>();

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
                    var auxClient = clients.Where(x => x.userId == Convert.ToInt64(_appUserSettingService.IdUser)).ToList();
                    Clients.ReplaceRange(auxClient);
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


