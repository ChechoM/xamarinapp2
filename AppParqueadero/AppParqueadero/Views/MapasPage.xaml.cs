using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using AppParqueadero.ViewModels;
using System;
using Xamarin.Essentials;
using System.Collections.Generic;
using AppParqueadero.Services;
using Newtonsoft.Json;

namespace AppParqueadero.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapasPage : ContentPage
    {
        private readonly MapasViewModel _viewModel;
        private readonly GoogleMapsService _GoogleMapsService;
        public MapasPage()

        {
            _GoogleMapsService = new GoogleMapsService();
            _viewModel = Startup.Resolve<MapasViewModel>();
            BindingContext = _viewModel;
            _viewModel.PropertyChanged += _viewModel_PropertyChanged;
            InitializeComponent();
        }

        private void _viewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

            var positionFalsa = new Position(6.248932112041483, -75.57290152500107);
            ClientLocationMap.MoveToRegion(new MapSpan(positionFalsa, 0.05, 0.05));

            foreach (var item in _viewModel.Client)
                {
                    if (
                    item.latitud != default &&
                    item.longitud != default &&
                    !string.IsNullOrEmpty(item.name))
                    {
                        var position = new Position(Convert.ToDouble(item.latitud), Convert.ToDouble(item.longitud));

                        Pin pin = new Pin();
                        pin.MarkerClicked += Map_PinClicked(position);                        
                        pin.Position = position;
                        pin.Label = item.name;
                        pin.Type = PinType.Place;

                        ClientLocationMap.Pins.Add(pin);




                    }
                }
        }
        private EventHandler<PinClickedEventArgs> Map_PinClicked(Position position)
        {
            Position positionFalsa = new Position(6.248932112041483, -75.57290152500107);
            Position posicionClick = new Position(position.Latitude, position.Longitude);

            var json = this._GoogleMapsService.GetRuta(positionFalsa, posicionClick).Result;

            return null;
        }
    }
}