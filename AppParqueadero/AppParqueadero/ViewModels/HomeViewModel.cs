using AppParqueadero.Data.Models.Dto;
using AppParqueadero.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppParqueadero.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {

        public HomeViewModel() 
        {
            AppearingCommand = new AsyncCommand(async () => await OnAppearingAsync());
            RouteComand = new Command(enrutar);

        }
        public Command RouteComand { get; }
        public ICommand AppearingCommand { get; set; }
        public ObservableRangeCollection<ListaImagenesDto> Imagenes { get; set; }
     

        private async Task OnAppearingAsync()
        {
            await getImagenes();
        }

        private async void enrutar(object parametro)
        {
            switch  (parametro.ToString())
            {
                case "1":
                        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
                    break;
                case "2":
                    //si opcion
                    break;
                default: 
                    break;
            }

        }
        public async Task getImagenes()
        {

             Imagenes = new ObservableRangeCollection<ListaImagenesDto>()
            {            
                 new ListaImagenesDto {imagen ="parqueadero1.jpg"},
                 new ListaImagenesDto {imagen ="parqueadero2.jpg"},
                 new ListaImagenesDto {imagen ="parqueadero3.jpg"}
            };

        }

    }
}
