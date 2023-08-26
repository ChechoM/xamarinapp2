using AppParqueadero.Data.Models;
using AppParqueadero.Data.Models.Dto;
using AppParqueadero.Services;
using AppParqueadero.Views;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace AppParqueadero.ViewModels
{
    public class ClientsViewModel : BaseViewModel
    {
        private readonly IClientService _clientService;
        private readonly IAppUserSettingService _appUserSettingService;
        private readonly IReporteService _reporteService;

        public ClientsViewModel(IClientService clientService, IAppUserSettingService appUserSettingService, IReporteService reporteService)
        {
            AppearingCommand = new AsyncCommand(async () => await OnAppearingAsync());
            Title = "Clients";
            _clientService = clientService;
            _appUserSettingService = appUserSettingService;
            _reporteService = reporteService;
            ClientTappedCommand = new AsyncCommand<long>(OnClientTapped);
        }

        public ObservableRangeCollection<ReporteVisitasDto> Clients { get; set; } = new ObservableRangeCollection<ReporteVisitasDto>();

        public ICommand AppearingCommand { get; set; }
        public ICommand ClientTappedCommand { get; set; }

        private async Task OnAppearingAsync()
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            try
            {
                IsBusy = true;
                var id = _appUserSettingService.IdUser;
                var clients = await _reporteService.GetCalificacionesPorCLiente(int.Parse(id));
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

        private Task OnClientTapped(long Id)
        {
            if (Id == null)
            {
                return Task.CompletedTask;
            }

            return Shell.Current.GoToAsync($"{nameof(ClientDetallePage)}?{nameof(ClientDetalleViewModel.ClientId)}={Id}");
        }
    }
}


